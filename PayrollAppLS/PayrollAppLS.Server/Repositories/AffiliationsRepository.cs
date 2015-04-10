using System.Linq;
using System.Runtime.Remoting.Messaging;
using Microsoft.LightSwitch;
using PayrollApp.Domain.Exceptions;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace PayrollApp.Infrastructure.Repositories
{
    public class AffiliationsRepository: Repository, IAffiliationsRepository
    {

        private Affiliation CreateModelAffiliation(LightSwitchApplication.Affiliation dbAffiliation)
        {
            return new AffiliationProxy(
                new AffiliationUidProxy(dbAffiliation.Uid),
                new EmployeeUidProxy(dbAffiliation.Employee.Uid),
                new OrganizationUidProxy(dbAffiliation.Organization.Uid),
                new AffiliationMemberIdProxy(dbAffiliation.ModifiedBy),
                new MoneyProxy(dbAffiliation.Dues));
        }


        public Affiliation Get(AffiliationUid uid)
        {
            var dbAffiliation = GetOrDefault(uid);
            CheckNotNull(dbAffiliation);

            return dbAffiliation;
        }

        public Affiliation GetOrDefault(AffiliationUid uid)
        {
            if (uid == null) throw new ArgumentNullException("uid");

            var dbAffiliation = DataWorkspace.ApplicationData.Affiliations
                .Where(x => x.Uid == uid)
                .SingleOrDefault();
            if(dbAffiliation == null)
                return null;

            return CreateModelAffiliation(dbAffiliation);
        }

        public IEnumerable<Affiliation> GetAll()
        {
            return DataWorkspace.ApplicationData.Affiliations
                .Select(x => CreateModelAffiliation(x))
                .Execute();
        }

        public void Update(Affiliation aggregate)
        {
            if (aggregate == null) throw new ArgumentNullException("aggregate");

            var dbAffiliation = DataWorkspace.ApplicationData.Affiliations
                .Where(x => x.Uid == aggregate.Uid)
                .SingleOrDefault();
            CheckNotNull(dbAffiliation);

            dbAffiliation.Dues = aggregate.Dues;
        }

        public void Insert(Affiliation aggregate)
        {
            if (aggregate == null) throw new ArgumentNullException("aggregate");

            var dbAffiliation = DataWorkspace.ApplicationData.Affiliations.AddNew();
            dbAffiliation.Uid = aggregate.Uid;
            dbAffiliation.Employee = DataWorkspace.ApplicationData.Employees
                .Where(x => x.Uid == aggregate.EmployeeUid)
                .Single();
            dbAffiliation.Organization = DataWorkspace.ApplicationData.Organizations
                .Where(x => x.Uid == aggregate.OrganizationUid)
                .Single();
            dbAffiliation.Dues = aggregate.Dues;
        }

        public void Delete(Affiliation aggregate)
        {
            if (aggregate == null) throw new ArgumentNullException("aggregate");

            var dbAffiliation = DataWorkspace.ApplicationData.Affiliations
                .Where(x => x.Uid == aggregate.Uid)
                .SingleOrDefault();
            CheckNotNull(dbAffiliation);

            dbAffiliation.Delete();
        }

        public Affiliation GetBy(OrganizationUid organizationUid, AffiliationMemberId memberId)
        {
            if (organizationUid == null) throw new ArgumentNullException("organizationUid");
            if (memberId == null) throw new ArgumentNullException("memberId");

            var dbAffiliation = DataWorkspace.ApplicationData.Affiliations
                .Where(x => x.Organization.Uid == organizationUid && x.MemberId == memberId)
                .Select(x => CreateModelAffiliation(x))
                .SingleOrDefault();
            CheckNotNull(dbAffiliation);

            return dbAffiliation;
        }

        public bool AffiliationExists(OrganizationUid organizationUid, AffiliationMemberId memberId, AffiliationUid exceptAffiliationUid = null)
        {
            if (exceptAffiliationUid != null)
                return DataWorkspace.ApplicationData.Affiliations
                    .Where(x => x.Uid != exceptAffiliationUid && x.Organization.Uid == organizationUid && x.MemberId == memberId).Count() > 0;

            return DataWorkspace.ApplicationData.Affiliations
                .Where(x => x.Organization.Uid == organizationUid && x.MemberId == memberId).Count() > 0;
        }

        public bool AffiliationExists(OrganizationUid organizationUid, EmployeeUid employeeUid, AffiliationUid exceptAffiliationUid)
        {
            if (exceptAffiliationUid != null)
                return DataWorkspace.ApplicationData.Affiliations
                    .Where(x => x.Uid != exceptAffiliationUid && x.Organization.Uid == organizationUid && x.Employee.Uid == employeeUid).Count() > 0;

            return DataWorkspace.ApplicationData.Affiliations
                .Where(x => x.Organization.Uid == organizationUid && x.Employee.Uid == employeeUid).Count() > 0;
        }
    }
}