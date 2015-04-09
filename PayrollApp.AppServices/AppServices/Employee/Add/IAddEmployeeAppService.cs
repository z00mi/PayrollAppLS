using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApp.AppServices
{
    public class AddEmployeeData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public IEnumerable<AddressData> Address { get; set; }
        public PaymentMethodData PaymentMethod { get; set; }
        public PaymentClassificationData PaymentClassification { get; set; }
        public PaymentScheduleTypeData PaymentScheduleType { get; set; }
    }

    public class AddressData
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
    }

    #region PaymentMethod

    public abstract class PaymentMethodData {}

    public class PaymentHoldMethodData : PaymentMethodData { }

    public class PaymentDirectMethodData : PaymentMethodData
    {
        public string Bank { get; set; }
        public string Account { get; set; }
    }

    public class PaymentMailMethodData : PaymentMethodData
    {
        public AddressData PaycheckAddress { get; set; }
    }

    #endregion 

    #region PaymentClassification

    public abstract class PaymentClassificationData {}

    public class PaymentCommisionedClassification : PaymentClassificationData
    {
        public decimal Salary { get; set; }
        public decimal Commision { get; set; }
    }

    public class PaymentHourlyClassification : PaymentClassificationData
    {
        public decimal HourlyRate { get; set; }
    }

    public class PaymentSalariedClassification : PaymentClassificationData
    {
        public decimal Salary { get; set; }
    }

    #endregion

    public enum PaymentScheduleTypeData
    {
        Weekly = 1,
        Biweekly = 2,
        Monthly = 3
    }



    public interface IAddEmployeeAppService
    {
        Guid Invoke(AddEmployeeData args);
    }
}
