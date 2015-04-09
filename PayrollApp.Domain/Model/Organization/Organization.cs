using System;
using PayrollApp.Domain.Exceptions;
using PayrollApp.Domain.Sepcifications;
using PayrollApp.Domain.Services;

namespace PayrollApp.Domain.Model
{
    /// <summary>
    /// Reprezentuje Organizację do której mogą należeć Pracownicy
    /// </summary>
    public class Organization : AggregateRoot<OrganizationUid>
    {
        /// <summary>
        /// Nazwa Organizacji
        /// </summary>
        public OrganizationName Name { get; private set; }

        /// <summary>
        /// Adres strony internetowej Organizacji lub null
        /// </summary>
        public NullableValObj<WebAddress> WebAddress { get; private set; }

        /// <summary>
        /// Ilość członków Organizacji
        /// </summary>
        public IntegerValueObject MembersCount { get; private set; } 

        /// <summary>
        /// Miesięczny budżet wyliczany na podstawie składek członków Organizacji
        /// </summary>
        public Money MonthlyBudget { get; private set; } 



        protected Organization(OrganizationUid uid, OrganizationName name, NullableValObj<WebAddress> webAddress, IntegerValueObject membersCount, Money monthlyBudget)
            : base(uid)
        {
            Name = name;
            WebAddress = webAddress;
            MembersCount = membersCount;
            MonthlyBudget = monthlyBudget;
        }

        public static Organization Create(
            OrganizationName name,
            NullableValObj<WebAddress> webAddress,
            IValidationSpecification<Organization> creatingValidationSpecification)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (creatingValidationSpecification == null) throw new ArgumentNullException("creatingValidationSpecification");

            var newOrganization = new Organization(OrganizationUid.CreateNew(), name, webAddress, 0, 0);

            if (!creatingValidationSpecification.IsSatisfiedBy(newOrganization))
                throw new ValidationException("Nie można utworzyć organizacji", creatingValidationSpecification.GetValidationErrorMessages());

            return newOrganization;
        }

        public void Update(
            OrganizationName name,
            NullableValObj<WebAddress> webAddress,
            IValidationSpecification<Organization> updatingValidationSpecification)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (updatingValidationSpecification == null) throw new ArgumentNullException("updatingValidationSpecification");

            var tmpOrganization = new Organization(this.Uid, name, webAddress, this.MembersCount, this.MonthlyBudget);

            if (!updatingValidationSpecification.IsSatisfiedBy(tmpOrganization)) 
                throw new ValidationException("Nie można zaktualizować organizacji", updatingValidationSpecification.GetValidationErrorMessages());

            Name = name;
            WebAddress = webAddress;
        }

        public void Delete(IValidationSpecification<Organization> deletingValidationSpecification)
        {
            if (deletingValidationSpecification == null) throw new ArgumentNullException("deletingValidationSpecification");

            if (!deletingValidationSpecification.IsSatisfiedBy(this))
                throw new ValidationException("Nie można usunąć organizacji", deletingValidationSpecification.GetValidationErrorMessages());
        }

        public void UpdateMembersCount(IOrganizationsService organizationsService)
        {
            MembersCount = organizationsService.GetMembersCount(this.Uid);
        }

        public void UpdateMonthlyBudget(IOrganizationsService organizationsService)
        {
            MonthlyBudget = organizationsService.CalculateMonthlyBudget(this.Uid);
        }
    }
}
