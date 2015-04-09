using System;

namespace PayrollApp.Domain.Model 
{
    /// <summary>
    /// Reprezentuje wyliczenia składników wynagrodzenia i składek Pracownika
    /// </summary>
    public class PayCheck: ValueObject
    {
        public EmployeeUid EmployeeUid { get; private set; }
        public Money GrossPay { get; private set; }
        public Money Deductions { get; private set; }

        protected PayCheck(EmployeeUid employeeUid, Money grossPay, Money deductions)
        {
            EmployeeUid = employeeUid;
            GrossPay = grossPay;
            Deductions = deductions;
        }

        public static PayCheck CreateNewEmptyPayCheck(EmployeeUid employeeUid)
        {
            return new PayCheck(employeeUid, Money.Create(0), Money.Create(0));
        }

        public static PayCheck Create(EmployeeUid employeeUid, Money grossPay, Money deductions)
        {
            if (employeeUid == null) throw new ArgumentNullException("employeeUid");
            if (grossPay == null) throw new ArgumentNullException("grossPay");
            if (deductions == null) throw new ArgumentNullException("deductions");

            return new PayCheck(employeeUid, grossPay, deductions);
        }

        public Money NetPay
        {
            get { return Money.Create(GrossPay - Deductions); }
        }

        public PayCheck AddGrossPay(Money grossPay)
        {
            return Create(EmployeeUid, this.GrossPay + grossPay, Deductions);
        }

        public PayCheck AddDeductions(Money deductions)
        {
            return Create(EmployeeUid, this.Deductions + deductions, Deductions);
        }
    }
}
