using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.LightSwitch;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;

namespace PayrollApp.Infrastructure.Repositories
{
    public class TimeCardsRepository : Repository, ITimeCardsRepository
    {

        public TimeCard Get(TimeCardUid uid)
        {
            var dbTimeCard = GetOrDefault(uid);
            CheckNotNull(dbTimeCard);

            return dbTimeCard;
        }

        public TimeCard GetOrDefault(TimeCardUid uid)
        {
            if (uid == null) throw new ArgumentNullException("uid");

            var dbTimeCard = DataWorkspace.ApplicationData.TimeCards.Where(x => x.Uid == uid).SingleOrDefault();
            if(dbTimeCard == null)
                return null;

            return CreateModelTimeCard(dbTimeCard);
        }

        public IEnumerable<TimeCard> GetAll()
        {
            return DataWorkspace.ApplicationData.TimeCards
                .Select(x => CreateModelTimeCard(x))
                .Execute();
        }

        public void Update(TimeCard aggregate)
        {
            if (aggregate == null) throw new ArgumentNullException("aggregate");

            var dbTimeCard = DataWorkspace.ApplicationData.TimeCards
                .Where(x => x.Uid == aggregate.Uid)
                .SingleOrDefault();
            CheckNotNull(dbTimeCard);

            dbTimeCard.TCDate = aggregate.Date;
            dbTimeCard.Hours = aggregate.Hours;
        }

        public void Insert(TimeCard aggregate)
        {
            if (aggregate == null) throw new ArgumentNullException("aggregate");

            var newDbTimeCard = DataWorkspace.ApplicationData.TimeCards.AddNew();
            newDbTimeCard.Uid = aggregate.Uid;
            newDbTimeCard.Employee = DataWorkspace.ApplicationData.Employees
                .Where(x => x.Uid == aggregate.EmployeeUid)
                .Single();
            newDbTimeCard.TCDate = aggregate.Date;
            newDbTimeCard.Hours = aggregate.Hours;
        }

        public void Delete(TimeCard aggregate)
        {
            if (aggregate == null) throw new ArgumentNullException("aggregate");

            var dbTimeCard = DataWorkspace.ApplicationData.TimeCards
                .Where(x => x.Uid == aggregate.Uid)
                .SingleOrDefault();
            CheckNotNull(dbTimeCard);

            dbTimeCard.Delete();
        }

        private TimeCard CreateModelTimeCard(LightSwitchApplication.TimeCard dbTimeCard)
        {
            return new TimeCardProxy(
                new TimeCardUidProxy(dbTimeCard.Uid),
                new EmployeeUidProxy(dbTimeCard.Employee.Uid),
                new DateProxy(dbTimeCard.TCDate),
                new HoursProxy(dbTimeCard.Hours)
            );
        }

    }
}