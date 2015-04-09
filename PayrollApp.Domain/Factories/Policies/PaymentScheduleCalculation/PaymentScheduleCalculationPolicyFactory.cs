using System;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Policies;
using System.Collections.Generic;

namespace PayrollApp.Domain.Factories
{
    public class PaymentScheduleCalculationPolicyFactory : IPaymentScheduleCalculationPolicyFactory
    {
        private readonly Dictionary<EmployeePaymentScheduleType, IPaymentScheduleCalculationPolicy> _policies;

        public PaymentScheduleCalculationPolicyFactory()
        {
            _policies = new Dictionary<EmployeePaymentScheduleType, IPaymentScheduleCalculationPolicy>();
        }

        private IPaymentScheduleCalculationPolicy GetPolicy(EmployeePaymentScheduleType employeePaymentScheduleType)
        {
            IPaymentScheduleCalculationPolicy policy;
            if (!_policies.TryGetValue(employeePaymentScheduleType, out policy))
            {
                policy = CreatePolicy(employeePaymentScheduleType);
                _policies.Add(employeePaymentScheduleType, policy);
            }
            return policy;
        }

        private IPaymentScheduleCalculationPolicy CreatePolicy(EmployeePaymentScheduleType employeePaymentScheduleType)
        {
            switch (employeePaymentScheduleType)
            {
                case EmployeePaymentScheduleType.WeeklySchedule:
                    return new WeeklySchedulePolicy();
                case EmployeePaymentScheduleType.BiweeklySchedule:
                    return new BiweeklySchedulePolicy();
                case EmployeePaymentScheduleType.MonthlySchedule:
                    return new MonthlySchedulePolicy();
                default:
                    throw new NotImplementedException();
            }
        }

        public IPaymentScheduleCalculationPolicy CreatePaymentSchedulePolicy(EmployeePaymentScheduleType employeePaymentScheduleType)
        {
            return GetPolicy(employeePaymentScheduleType);
        }
    }
}
