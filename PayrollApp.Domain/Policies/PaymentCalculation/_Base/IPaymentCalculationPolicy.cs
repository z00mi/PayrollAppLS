using PayrollApp.Domain.Model;

namespace PayrollApp.Domain.Policies
{
    /// <summary>
    /// Polityka obliczania wypłaty Pracownika
    /// </summary>
    public interface IPaymentCalculationPolicy
    {
        void CalculatePay(ref PayCheck payCheck);
    }
}
