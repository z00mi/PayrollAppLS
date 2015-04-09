using System;

namespace PayrollApp.Domain.Model
{
    /// <summary>
    /// Rekord Listy Płac konkretnego Pracownika
    /// </summary>
    public class PayrollItem: ValueObject
    {
        public EmployeeUid EmployeeUid { get; private set; }
        public Money GrossPay { get; private set; }
        public Money Deductions { get; private set; }
        public Money NetPay { get; private set; }

        protected PayrollItem(EmployeeUid employeeUid, Money grossPay, Money deductions, Money netPay)
        {
            EmployeeUid = employeeUid;
            GrossPay = grossPay;
            Deductions = deductions;
            NetPay = netPay;
        }

        public static PayrollItem Create(EmployeeUid employeeUid, Money grossPay, Money deductions, Money netPay)
        {
            if (employeeUid == null) throw new ArgumentNullException("employeeUid");
            if (grossPay == null) throw new ArgumentNullException("grossPay");
            if (deductions == null) throw new ArgumentNullException("deductions");
            if (netPay == null) throw new ArgumentNullException("netPay");

            return new PayrollItem(employeeUid, grossPay, deductions, netPay);
        }
    }
}
