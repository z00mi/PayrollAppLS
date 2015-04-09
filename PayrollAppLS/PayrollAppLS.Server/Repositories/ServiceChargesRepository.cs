using System.Linq;
using Microsoft.LightSwitch;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace PayrollApp.Infrastructure.Repositories
{
    public class ServiceChargesRepository: Repository, IServiceChargesRepository
    {

        public ServiceCharge Get(ServiceChargeUid uid)
        {
            var dbServiceCharge = GetOrDefault(uid);
            CheckNotNull(dbServiceCharge);

            return dbServiceCharge;
        }

        public ServiceCharge GetOrDefault(ServiceChargeUid uid)
        {
            if (uid == null) throw new ArgumentNullException("uid");

            var dbServiceCharge = DataWorkspace.ApplicationData.ServiceCharges.Where(x => x.Uid == uid).SingleOrDefault();
            if (dbServiceCharge == null)
                return null;

            return CreateModelServiceCharge(dbServiceCharge);
        }

        public IEnumerable<ServiceCharge> GetAll()
        {
            return DataWorkspace.ApplicationData.ServiceCharges
                .Select(x => CreateModelServiceCharge(x))
                .Execute();
        }

        public void Update(ServiceCharge aggregate)
        {
            if (aggregate == null) throw new ArgumentNullException("aggregate");

            var dbServiceCharge = DataWorkspace.ApplicationData.ServiceCharges
                .Where(x => x.Uid == aggregate.Uid)
                .SingleOrDefault();
            CheckNotNull(dbServiceCharge);

            dbServiceCharge.SCDate = aggregate.Date;
            dbServiceCharge.Amount = aggregate.Amount;
        }

        public void Insert(ServiceCharge aggregate)
        {
            if (aggregate == null) throw new ArgumentNullException("aggregate");

            var dbServiceCharge = DataWorkspace.ApplicationData.ServiceCharges.AddNew();
            dbServiceCharge.Uid = aggregate.Uid;
            dbServiceCharge.Affiliation = DataWorkspace.ApplicationData.Affiliations
                .Where(x => x.Uid == aggregate.Uid)
                .Single();
            dbServiceCharge.SCDate = aggregate.Date;
            dbServiceCharge.Amount = aggregate.Amount;
        }

        public void Delete(ServiceCharge aggregate)
        {
            if (aggregate == null) throw new ArgumentNullException("aggregate");

            var dbServiceCharge = DataWorkspace.ApplicationData.ServiceCharges
                .Where(x => x.Uid == aggregate.Uid)
                .SingleOrDefault();
            CheckNotNull(dbServiceCharge);

            dbServiceCharge.Delete();
        }

        private ServiceCharge CreateModelServiceCharge(LightSwitchApplication.ServiceCharge dbServiceCharge)
        {
            return new ServiceChargeProxy(
                new ServiceChargeUidProxy(dbServiceCharge.Uid),
                new AffiliationUidProxy(dbServiceCharge.Affiliation.Uid),
                new DateProxy(dbServiceCharge.SCDate),
                new MoneyProxy(dbServiceCharge.Amount)
            );
        }
    }
}