using PayrollApp.Domain.Specifications;

namespace PayrollApp.Domain.Sepcifications
{
    /// <summary>
    /// Klasa bazowa specyfikacji warunków walidacji
    /// </summary>
    public abstract class ValidationSpecification<T> : Specification<T>, IValidationSpecification<T>
    {
        private string _validationErrorMessages;

        public override bool IsSatisfiedBy(T o)
        {
            _validationErrorMessages = "";
            return IsSatisfiedBy(o, ref _validationErrorMessages);
        }

        public string GetValidationErrorMessages()
        {
            return _validationErrorMessages;
        }
    }
}
