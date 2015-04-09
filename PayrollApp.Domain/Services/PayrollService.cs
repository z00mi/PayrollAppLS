using System;
using System.Collections.Generic;
using PayrollApp.Domain.Events;
using PayrollApp.Domain.Factories;
using PayrollApp.Domain.Model;

namespace PayrollApp.Domain.Services
{
    public class PayrollService : IPayrollService
    {
        private readonly IPaymentScheduleCalculationPolicyFactory _paymentSchedulePolicyFactory;
        private readonly IPaymentCalculationPolicyFactory _paymentClassificationPolicyFactory;
        private readonly IDeductionsCalculationPolicyFactory _deductionsCalculationPolicyFactory;
        private readonly IPayrollValidationSpecificationFactory _payrollValidationSpecificationFactory;
        private readonly IDomainEventsPublisher _eventsPublisher;



        public PayrollService(
            IPaymentScheduleCalculationPolicyFactory paymentSchedulePolicyFactory,
            IPaymentCalculationPolicyFactory paymentClassificationPolicyFactory,
            IDeductionsCalculationPolicyFactory deductionsCalculationPolicyFactory,
            IPayrollValidationSpecificationFactory payrollValidationSpecificationFactory,
            IDomainEventsPublisher eventsPublisher)
        {
            _paymentSchedulePolicyFactory = paymentSchedulePolicyFactory;
            _paymentClassificationPolicyFactory = paymentClassificationPolicyFactory;
            _deductionsCalculationPolicyFactory = deductionsCalculationPolicyFactory;
            _payrollValidationSpecificationFactory = payrollValidationSpecificationFactory;
            _eventsPublisher = eventsPublisher;
        }

        public Payroll GeneratePayroll(IEnumerable<Employee> employees, Date forDate)
        {
            var payroll = Payroll.Create(
                DateAndTime.Create(DateTime.Now),
                _payrollValidationSpecificationFactory.GetGeneratingValidationSpecification());

            foreach (var employee in employees)
            {
                var paymentSchedule = _paymentSchedulePolicyFactory.CreatePaymentSchedulePolicy(employee.PaymentScheduleType);
                if (employee.IsPayDay(forDate, paymentSchedule))
                {
                    var payPeriodStartDate = paymentSchedule.GetPayPeriodStartDate(forDate);

                    var paymentCalculationPolicy = _paymentClassificationPolicyFactory.CreatePaymentCalculationPolicy(
                            employee.PaymentClassification,
                            paymentSchedule.GetPayPeriodStartDate(forDate), 
                            forDate);

                    var deductionsCalculationPolicy = _deductionsCalculationPolicyFactory.CreateDeductionsCalculationPolicy(
                            /*employee.Affiliations*/null, //TODO !!!
                            payPeriodStartDate,
                            forDate);

                    var payCheck = employee.GeneratePayCheck(paymentCalculationPolicy, deductionsCalculationPolicy);

                    payroll.AddEmployeePayCheck(employee.Uid, payCheck);
                }
            }

            _eventsPublisher.Publish(PayrollGeneratedEvent.Create(payroll.Uid));

            return payroll;
        }
    }
}
