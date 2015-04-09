using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayrollApp.Domain.Model;

namespace PayrollApp.Infrastructure.Repositories
{
    public class EmployeeProxy : Employee
    {
        public EmployeeProxy(EmployeeUid uid, EmployeeFirstName firstName, EmployeeLastName lastName, NullableValObj<EmailAddress> email, NullableValObj<PhoneNumber> phone, IEnumerable<Address> addresses, EmployeePaymentScheduleType paymentScheduleType, PaymentClassification paymentClassification, PaymentMethod paymentMethod) : base(uid, firstName, lastName, email, phone, addresses, paymentScheduleType, paymentClassification, paymentMethod)
        {
        }
    }
}