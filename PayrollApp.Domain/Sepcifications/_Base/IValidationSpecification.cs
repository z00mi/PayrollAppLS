using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApp.Domain.Sepcifications
{
    /// <summary>
    /// Specyfikacja warunków walidacji
    /// </summary>
    public interface IValidationSpecification<in T>
    {
        bool IsSatisfiedBy(T o);
        string GetValidationErrorMessages();
    }
}
