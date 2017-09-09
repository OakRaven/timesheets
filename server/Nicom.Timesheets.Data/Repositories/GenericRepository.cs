using Nicom.Timesheets.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Nicom.Timesheets.Data.Repositories
{
    public abstract class GenericRepository<C, E, D> : IGenericRepository<E, D>
        where E : class
        where D : class
        where C : DbContext, new()
    {
        protected const int ALL_RECORDS = 9999999;
        protected string[] navigationProperties;
        private C entities;

        public GenericRepository(string[] navigationProperties)
        {
            this.navigationProperties = navigationProperties;

            entities = new C();
            InitializeAutoMapper();
        }

        private GenericRepository()
        {
        }

        public C Context
        {
            get => entities; set { entities = value; }
        }

        public string[] NavigationProperties { get; }

        public abstract void AddOrUpdate(E entity, string by, DateTime on);

        public int Count()
        {
            return entities.Set<D>().Count();
        }

        public int Count(Expression<Func<D, bool>> predicate)
        {
            return entities.Set<D>().Count(predicate);
        }

        public virtual void Delete(Expression<Func<D, bool>> predicate)
        {
            D item = this.entities.Set<D>().FirstOrDefault(predicate);
            if (item != null)
            {
                entities.Set<D>().Remove(item);
            }
        }

        public abstract void DeleteById(int id, string deletedBy, DateTime deletedOn);

        public virtual void Edit(Expression<Func<D, bool>> predicate)
        {
            D item = this.entities.Set<D>().FirstOrDefault(predicate);
            if (item != null)
            {
                entities.Entry(item).State = EntityState.Modified;
            }
        }

        public abstract IEnumerable<E> FetchAll(int maxRecords = 100, bool activeOnly = true);

        public abstract E FetchById(int id);

        public IQueryable<D> GetDbWithIncludes(string[] navigationProperties)
        {
            IQueryable<D> query = this.entities.Set<D>();

            foreach (string navProp in navigationProperties)
            {
                if (navProp.StartsWith("!") == false)
                {
                    query = query.Include(navProp);
                }
            }

            return query;
        }

        public abstract void InitializeAutoMapper();

        public virtual IEnumerable<E> List()
        {
            return List(new string[] { });
        }

        public virtual IEnumerable<E> List(string[] navigationProperties)
        {
            IQueryable<D> query = this.entities.Set<D>();

            foreach (string navProp in navigationProperties)
            {
                if (navProp.StartsWith("!") == false)
                {
                    query = query.Include(navProp);
                }
            }

            return MapFromDbCollection(query.ToArray(), navigationProperties);
        }

        public virtual IEnumerable<E> List(Expression<Func<D, bool>> predicate)
        {
            return this.List(predicate, new string[] { });
        }

        public virtual IEnumerable<E> List(Expression<Func<D, bool>> predicate, string[] navigationProperties)
        {
            IQueryable<D> query = GetDbWithIncludes(navigationProperties).Where(predicate);

            return MapFromDbCollection(query.ToArray(), navigationProperties);
        }

        public IEnumerable<E> List(bool includeAllNavigationProperties = false)
        {
            if (includeAllNavigationProperties == true)
            {
                return List(navigationProperties);
            }
            else
            {
                return List();
            }
        }

        public IEnumerable<E> List(Expression<Func<D, bool>> predicate, bool includeAllNavigationProperties = false)
        {
            if (includeAllNavigationProperties == true)
            {
                return List(predicate, navigationProperties);
            }
            else
            {
                return List(predicate);
            }
        }

        public virtual E MapFromDb(D entity, bool includeAllNavigationProperties = false)
        {
            if (includeAllNavigationProperties == true)
            {
                return MapFromDb(entity, navigationProperties);
            }
            else
            {
                return MapFromDb(entity, new string[] { });
            }
        }

        public abstract E MapFromDb(D entity, string[] navigationProperties);

        public virtual IEnumerable<E> MapFromDbCollection(IEnumerable<D> dbCollection, string[] navigationProperties)
        {
            var collection = new List<E>();

            foreach (var item in dbCollection)
            {
                collection.Add(MapFromDb(item, navigationProperties));
            }

            return collection;
        }

        public virtual IEnumerable<E> MapFromDbCollection(IEnumerable<D> dbCollection, bool includeAllNavigationProperties = false)
        {
            if (includeAllNavigationProperties == true)
            {
                return MapFromDbCollection(dbCollection, navigationProperties);
            }
            else
            {
                return MapFromDbCollection(dbCollection, null);
            }
        }

        public void Save()
        {
            try
            {
                Context.ChangeTracker.DetectChanges();
                Context.SaveChanges();

                this.entities = new C();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public virtual void Save(E entity, string savedBy, DateTime savedOn)
        {
            AddOrUpdate(entity, savedBy, savedOn);
        }

        public virtual void SaveAll(IEnumerable<E> entities, string by, DateTime on)
        {
            foreach (var entity in entities)
            {
                AddOrUpdate(entity, by, on);
            }
        }

        public E Single(Expression<Func<D, bool>> predicate)
        {
            return Single(predicate, new string[] { });
        }

        public E Single(Expression<Func<D, bool>> predicate, string[] navigationProperties)
        {
            D item = GetDbWithIncludes(navigationProperties).SingleOrDefault(predicate);

            if (item != null)
            {
                return MapFromDb(item, navigationProperties);
            }
            else
            {
                return null;
            }
        }

        public E Single(Expression<Func<D, bool>> predicate, bool includeAllNavigationProperties = false)
        {
            if (includeAllNavigationProperties == true)
            {
                return Single(predicate, navigationProperties);
            }
            else
            {
                return Single(predicate);
            }
        }

        public void ThrowEntityFrameworkError(DbEntityValidationException exception)
        {
            var errorMessages = new List<string>();

            foreach (var error in exception.EntityValidationErrors)
            {
                foreach (var validationError in error.ValidationErrors)
                {
                    errorMessages.Add(string.Format("{0} - {1}", validationError.PropertyName, validationError.ErrorMessage));
                }
            }

            throw new Exception(string.Format("DB Error: {0}", string.Join(",", errorMessages)));
        }

        /// <summary>
        /// Extracts the Id property value for the item provided.
        /// </summary>
        /// <param name="item">item with Id property</param>
        /// <returns>Returns 0 if item is null.  Returns integer value
        /// of item's Id property.</returns>
        protected int GetNonNullableIdValue(object item)
        {
            if (item == null)
            {
                return 0;
            }

            try
            {
                return (int) item.GetType().GetProperty("Id").GetValue(item, null);
            }
            catch (Exception e)
            {
                throw new InvalidCastException(e.Message);
            }
        }

        /// <summary>
        /// Extracts the Id property value for the item provided.
        /// </summary>
        /// <param name="item">item with Id property</param>
        /// <returns>Returns null if item is null.  Returns nullable integer value
        /// of item's Id property.</returns>
        protected int? GetNullableIdValue(object item)
        {
            if (item == null)
            {
                return null;
            }

            try
            {
                return (int?) item.GetType().GetProperty("Id").GetValue(item, null);
            }
            catch (Exception e)
            {
                throw new InvalidCastException(e.Message);
            }
        }
    }
}