using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Sepcifications;

namespace PayrollApp.Domain.Factories
{
    public interface IOrganizationValidationSpecificationFactory
    {
        IValidationSpecification<Organization> GetCreatingValidationSpecification();
        IValidationSpecification<Organization> GetUpdatingValidationSpecification();
        IValidationSpecification<Organization> GetDeletingValidationSpecification();
    }
}
