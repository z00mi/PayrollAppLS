using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Sepcifications;

namespace PayrollApp.Domain.Factories
{
    public interface IServiceChargeValidationSpecificationFactory
    {
        IValidationSpecification<ServiceCharge> GetCreatingValidationSpecification();
        IValidationSpecification<ServiceCharge> GetDeletingValidationSpecification();
    }
}
