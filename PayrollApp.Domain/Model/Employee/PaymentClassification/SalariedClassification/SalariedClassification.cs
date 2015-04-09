using System;

namespace PayrollApp.Domain.Model
{
    /// <summary>
    /// Dane Pracownika pracującego na etat
    /// </summary>
    public class SalariedClassification: PaymentClassification
    {
        /// <summary>
        /// Wynagrodzenie
        /// </summary>
        public Money Salary { get; private set; }
        
        protected SalariedClassification(Money salary)
        {
            Salary = salary;
        }

        public static SalariedClassification Create(Money salary)
        {
            if (salary == null) throw new ArgumentNullException("salary");

            return new SalariedClassification(salary);
        }
    }
}
