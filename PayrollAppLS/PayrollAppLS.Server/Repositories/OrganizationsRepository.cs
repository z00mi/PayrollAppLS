using System.Linq;
using Microsoft.LightSwitch;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace PayrollApp.Infrastructure.Repositories
{
    public class OrganizationsRepository: Repository, IOrganizationsRepository
    {

        public Organization Get(OrganizationUid uid)
        {
            var dbOrganization = GetOrDefault(uid);
            CheckNotNull(dbOrganization);

            return dbOrganization;
        }

        public Organization GetOrDefault(OrganizationUid uid)
        {
            if (uid == null) throw new ArgumentNullException("uid");

            var dbOrganization = DataWorkspace.ApplicationData.Organizations
                .Where(x => x.Uid == uid)
                .SingleOrDefault();
            if (dbOrganization == null)
                return null;

            return CreateModelOrganization(dbOrganization);
        }

        public IEnumerable<Organization> GetAll()
        {
            return DataWorkspace.ApplicationData.Organizations
                .Select(x => CreateModelOrganization(x))
                .Execute();
        }

        public void Update(Organization aggregate)
        {
            if (aggregate == null) throw new ArgumentNullException("aggregate");

            var dbOrganization = DataWorkspace.ApplicationData.Organizations
                .Where(x => x.Uid == aggregate.Uid)
                .SingleOrDefault();
            CheckNotNull(dbOrganization);

            dbOrganization.Name = aggregate.Name;
            dbOrganization.WebAddress = aggregate.WebAddress.Value;
            dbOrganization.MembersCount = aggregate.MembersCount;
            dbOrganization.MonthlyBudget = aggregate.MonthlyBudget;
        }

        public void Insert(Organization aggregate)
        {
            if (aggregate == null) throw new ArgumentNullException("aggregate");

            var dbOrganization = DataWorkspace.ApplicationData.Organizations.AddNew();
            dbOrganization.Uid = aggregate.Uid;
            dbOrganization.Name = aggregate.Name;
            dbOrganization.WebAddress = aggregate.WebAddress.Value;
            dbOrganization.MembersCount = aggregate.MembersCount;
            dbOrganization.MonthlyBudget = aggregate.MonthlyBudget;
        }

        public void Delete(Organization aggregate)
        {
            if (aggregate == null) throw new ArgumentNullException("aggregate");

            var dbOrganization = DataWorkspace.ApplicationData.Organizations
                .Where(x => x.Uid == aggregate.Uid)
                .SingleOrDefault();
            CheckNotNull(dbOrganization);

            dbOrganization.Delete();
        }

        public bool OrganizationExists(OrganizationName organizationName, OrganizationUid exceptOrganizationUid)
        {
            if (exceptOrganizationUid != null)
                return DataWorkspace.ApplicationData.Organizations
                    .Where(x => x.Uid != exceptOrganizationUid && x.Name == organizationName).Count() > 0;

            return DataWorkspace.ApplicationData.Organizations
                .Where(x => x.Name == organizationName).Count() > 0;
        }

        private Organization CreateModelOrganization(LightSwitchApplication.Organization dbOrganization)
        {
            return new OrganizationProxy(
                new OrganizationUidProxy(dbOrganization.Uid),
                new OrganizationNameProxy(dbOrganization.Name),
                dbOrganization.WebAddress != null ? new WebAddressProxy(dbOrganization.WebAddress) : null,
                new IntegerValueObjectProxy(dbOrganization.MembersCount),
                new MoneyProxy(dbOrganization.MonthlyBudget));
        }


    }
}