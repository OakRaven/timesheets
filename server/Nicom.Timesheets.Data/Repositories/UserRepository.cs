using AutoMapper;
using Nicom.Timesheets.Data.Interfaces;
using Nicom.Timesheets.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Nicom.Timesheets.Data.Repositories
{
    public class UserRepository : GenericRepository<TimesheetDb, UserModel, User>, IUserRepository
    {
        public UserRepository() : base(new[] { "Timesheets", "ClientUserRates", "ProjectUserRates" })
        {
        }

        public override void AddOrUpdate(UserModel entity, string by, DateTime on)
        {
            User item;

            if (entity.Id == 0)
            {
                item = Context.Users.FirstOrDefault(i => i.Id == entity.Id);

                if (item == null)
                {
                    item = new User();
                }
            }
            else
            {
                item = Context.Users.FirstOrDefault(i => i.Id == entity.Id);
            }

            if (item != null)
            {
                item.FirstName = entity.FirstName;
                item.LastName = entity.LastName;
                item.EmailAddress = entity.EmailAddress;
                item.IsActive = entity.IsActive;
                item.LoginName = entity.LoginName;
                item.IsAdministrator = entity.IsAdministrator;
                item.StandardRate = entity.StandardRate;
                item.HoursPerWeek = entity.HoursPerWeek;
                item.PlannedBillUtilPct = entity.PlannedBillUtilPct;
                item.IncludeUtilization = entity.IncludeUtilization;
            }

            if (item.Id == 0)
            {
                Context.Users.Add(item);
            }
            Context.Entry(item).State = item.Id == 0 ? EntityState.Added : EntityState.Modified;

            Save();
        }

        public override void DeleteById(int id, string deletedBy, DateTime deletedOn)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<UserModel> FetchAll(int maxRecords = 100, bool activeOnly = true)
        {
            var query = List();

            if (activeOnly)
            {
                query = query.Where(i => i.IsActive == true);
            }

            return query.Take(maxRecords);
        }

        public override UserModel FetchById(int id)
        {
            return Single(i => i.Id == id);
        }

        public override UserModel MapFromDb(User entity, string[] navigationProperties)
        {
            var item = Mapper.Map<UserModel>(entity);

            if (navigationProperties.Contains("Timesheets"))
            {
                item.Timesheets = Mapper.Map<TimesheetModel[]>(entity.Timesheets);
            }

            if (navigationProperties.Contains("ClientUserRates"))
            {
                item.ClientUserRates = Mapper.Map<ClientUserRateModel[]>(entity.ClientUserRates);
            }

            if (navigationProperties.Contains("ProjectUserRates"))
            {
                item.ProjectUserRates = Mapper.Map<ProjectUserRateModel[]>(entity.ProjectUserRates);
            }

            return item;
        }
    }
}