using System;
using PayrollApp.Domain.Events;
using PayrollApp.Domain.Exceptions;
using PayrollApp.Domain.Sepcifications;

namespace PayrollApp.Domain.Model
{
    /// <summary>
    /// Reprezentuje przynależność Pracownika do Organizacji
    /// </summary>
    public class Affiliation : AggregateRoot<AffiliationUid>
    {
        /// <summary>
        /// Id Pracownika
        /// </summary>
        public EmployeeUid EmployeeUid { get; private set; }

        /// <summary>
        /// Id Organizacji
        /// </summary>
        public OrganizationUid OrganizationUid { get; private set; }

        /// <summary>
        /// Identyfikator uczestnika w ramach Organizacji
        /// </summary>
        public AffiliationMemberId MemberId { get; set; }

        /// <summary>
        /// Wielkość stałej składki odprowadzanej na rzecz Organizacji przez Pracownika (za okres wg harmonogramu wpłat na rzecz Organizacji)
        /// </summary>
        public Money Dues { get; private set; }


        protected Affiliation(AffiliationUid uid, EmployeeUid employeeUid, OrganizationUid organizationUid, AffiliationMemberId memberId, Money dues) : base(uid)
        {
            EmployeeUid = employeeUid;
            OrganizationUid = organizationUid;
            MemberId = memberId;
            Dues = dues;
        }

        public static Affiliation Create(
            EmployeeUid employeeUid,
            OrganizationUid organizationUid,
            AffiliationMemberId memberId,
            Money dues,
            IValidationSpecification<Affiliation> creatingValidationSpecification)
        {
            if (employeeUid == null) throw new ArgumentNullException("employeeUid");
            if (organizationUid == null) throw new ArgumentNullException("organizationUid");
            if (memberId == null) throw new ArgumentNullException("memberId");
            if (dues == null) throw new ArgumentNullException("dues");
            if (creatingValidationSpecification == null) throw new ArgumentNullException("creatingValidationSpecification");

            var newAffiliation = new Affiliation(AffiliationUid.CreateNew(), employeeUid, organizationUid, memberId, dues);

            if (!creatingValidationSpecification.IsSatisfiedBy(newAffiliation))
                throw new ValidationException("Nie można utworzyć przynależności", creatingValidationSpecification.GetValidationErrorMessages());

            PublishEvent(MemberAddedToOrganizationEvent.Create(organizationUid));

            return newAffiliation;
        }

        public void Update(
            Money dues,
            AffiliationMemberId memberId,
            IValidationSpecification<Affiliation> updatingValidationSpecification)
        {
            if (dues == null) throw new ArgumentNullException("dues");
            if (memberId == null) throw new ArgumentNullException("memberId");
            if (updatingValidationSpecification == null) throw new ArgumentNullException("updatingValidationSpecification");

            var tmpAffiliation = new Affiliation(Uid, EmployeeUid, OrganizationUid, memberId, dues);

            if (!updatingValidationSpecification.IsSatisfiedBy(tmpAffiliation))
                throw new ValidationException("Nie można zaktualizować przynależności", updatingValidationSpecification.GetValidationErrorMessages());

            MemberId = memberId;
            var duesChanged = Dues != dues;
            Dues = dues;

            if (duesChanged)
                PublishEvent(MemberDuesChangedEvent.Create(this.Uid));
        }

        public void Delete(IValidationSpecification<Affiliation> deletingValidationSpecification)
        {
            if (deletingValidationSpecification == null) throw new ArgumentNullException("deletingValidationSpecification");

            if (!deletingValidationSpecification.IsSatisfiedBy(this))
                throw new ValidationException("Nie można usunąć przynależności", deletingValidationSpecification.GetValidationErrorMessages());

            PublishEvent(MemberRemovedFromOrganizationEvent.Create(this.OrganizationUid));
        }
    }
}
