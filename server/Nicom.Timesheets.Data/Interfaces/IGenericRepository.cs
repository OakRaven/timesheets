using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;

namespace Nicom.Timesheets.Data.Interfaces
{
    public interface IGenericRepository<E, D> where E : class where D : class
    {
        void AddOrUpdate(E entity, string by, DateTime on);

        int Count();

        int Count(Expression<Func<D, bool>> predicate);

        void Delete(Expression<Func<D, bool>> predicate);

        void DeleteById(int id, string deletedBy, DateTime deletedOn);

        void Edit(Expression<Func<D, bool>> predicate);

        IEnumerable<E> FetchAll(int maxRecords = 100, bool activeOnly = true);
        
        E FetchById(int id);

        IQueryable<D> GetDbWithIncludes(string[] navigationProperties);

        IEnumerable<E> List();

        IEnumerable<E> List(string[] navigationProperties);

        IEnumerable<E> List(bool includeAllNavigationProperties = false);

        IEnumerable<E> List(Expression<Func<D, bool>> predicate);

        IEnumerable<E> List(Expression<Func<D, bool>> predicate, bool includeAllNavigationProperties = false);

        IEnumerable<E> List(Expression<Func<D, bool>> predicate, string[] navigationProperties);

        void Save();
        
        void Save(E entity, string savedBy, DateTime savedOn);

        void SaveAll(IEnumerable<E> entities, string by, DateTime on);

        E Single(Expression<Func<D, bool>> predicate);

        E Single(Expression<Func<D, bool>> predicate, bool includeAllNavigationProperties = false);

        E Single(Expression<Func<D, bool>> predicate, string[] navigationProperties);

        void ThrowEntityFrameworkError(DbEntityValidationException exception);
    }
}