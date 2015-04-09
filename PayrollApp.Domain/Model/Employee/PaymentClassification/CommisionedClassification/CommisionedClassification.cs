using System;

namespace PayrollApp.Domain.Model
{
    /// <summary>
    /// Dane Pracownika pracującego w systemie prowizyjnym
    /// </summary>
    public class CommisionedClassification: PaymentClassification
    {
        /// <summary>
        /// Płaca podstawowa
        /// </summary>
        public Money Salary { get; private set; }
        /// <summary>
        /// Procent prowizji od sprzedaży
        /// </summary>
        public CommisionedClassificationCommision Commision { get; private set; }

        protected CommisionedClassification(Money salary, CommisionedClassificationCommision commision)
        {
            Salary = salary;
            Commision = commision;
        }

        public static CommisionedClassification Create(Money salary, CommisionedClassificationCommision commision)
        {
            if (salary == null) throw new ArgumentNullException("salary");
            if (commision == null) throw new ArgumentNullException("commision");

            return  new CommisionedClassification(salary, commision);
        }
    }
}
