using PayrollApp.Domain.Model;

namespace PayrollApp.Domain.Policies
{
    /// <summary>
    /// Polityka wyliczania składek odprowadzanych przez członka na rzecz Organizacji
    /// </summary>
    public interface IDeductionsCalculationPolicy
    {
        void CalculateDeductions(ref PayCheck payCheck);
    }
}
