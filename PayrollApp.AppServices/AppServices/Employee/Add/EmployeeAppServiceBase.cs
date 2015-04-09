using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollApp.Domain.Factories;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;

namespace PayrollApp.AppServices
{
    public class EmployeeAppServiceBase
    {
        protected EmployeePaymentScheduleType GetPaymentScheduleType(PaymentScheduleTypeData paymentScheduleTypeData)
        {
            return (EmployeePaymentScheduleType)paymentScheduleTypeData;
        }

        protected PaymentClassification GetPaymentClassification(PaymentClassificationData paymentClassificationData)
        {
            if (paymentClassificationData is PaymentCommisionedClassification)
            {
                var data = (PaymentCommisionedClassification)paymentClassificationData;
                return CommisionedClassification.Create(data.Salary, data.Commision);
            }

            if (paymentClassificationData is PaymentHourlyClassification)
            {
                var data = (PaymentHourlyClassification)paymentClassificationData;
                return HourlyClassification.Create(data.HourlyRate);
            }

            if (paymentClassificationData is PaymentSalariedClassification)
            {
                var data = (PaymentSalariedClassification)paymentClassificationData;
                return SalariedClassification.Create(data.Salary);
            }

            throw new NotImplementedException();
        }

        protected PaymentMethod GetPaymentMethod(PaymentMethodData paymentMethodData)
        {
            if (paymentMethodData is PaymentHoldMethodData)
            {
                var data = (PaymentHoldMethodData) paymentMethodData;
                return HoldMethod.Create();
            }

            if (paymentMethodData is PaymentDirectMethodData)
            {
                var data = (PaymentDirectMethodData) paymentMethodData;
                return DirectMethod.Create(data.Bank, data.Account);
            }

            if (paymentMethodData is PaymentMailMethodData)
            {
                var data = (PaymentMailMethodData) paymentMethodData;
                return MailMethod.Create(Address.Create(data.PaycheckAddress.City, data.PaycheckAddress.Street, data.PaycheckAddress.Number));
            }

            throw new NotImplementedException();
        }

    }
}
