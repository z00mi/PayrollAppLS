using System;

namespace PayrollApp.Domain.Model
{
    /// <summary>
    /// Dane Pracownika pracującego w systemie godzinowym
    /// </summary>
    public class HourlyClassification: PaymentClassification
    {
        /// <summary>
        /// Stawka godzinowa wynagrodzenia
        /// </summary>
        public Money HourlyRate { get; private set; }
        
        protected HourlyClassification(Money hourlyRate)
        {
            HourlyRate = hourlyRate;
        }

        public static HourlyClassification Create(Money hourlyRate)
        {
            if (hourlyRate == null) throw new ArgumentNullException("hourlyRate");

            return new HourlyClassification(hourlyRate);
        }
    }
}
