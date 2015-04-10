using System.Linq;
using Microsoft.LightSwitch;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace PayrollApp.Infrastructure.Repositories
{
    public class PayrollsRepository: Repository, IPayrollsRepository
    {

        private Payroll CreateModelPayroll(LightSwitchApplication.Payroll dbPayroll)
        {
            return new PayrollProxy(
                new PayrollUidProxy(dbPayroll.Uid),
                new DateAndTimeProxy(dbPayroll.TimeGenerated),
                dbPayroll.PayrollItems.Select(item =>
                    new PayrollItemProxy(
                        new EmployeeUidProxy(item.Employee.Uid),
                        new MoneyProxy(item.GrossPay),
                        new MoneyProxy(item.Deductions),
                        new MoneyProxy(item.NetPay)
                    )
                )
            );
        }

        public Payroll Get(PayrollUid uid)
        {
            var dbPayroll = GetOrDefault(uid);
            CheckNotNull(dbPayroll);

            return dbPayroll;
        }

        public Payroll GetOrDefault(PayrollUid uid)
        {
            if (uid == null) throw new ArgumentNullException("uid");

            var dbPayroll = DataWorkspace.ApplicationData.Payrolls
                .Where(x => x.Uid == uid)
                .SingleOrDefault();
            if (dbPayroll == null)
                return null;

            return CreateModelPayroll(dbPayroll);
        }

        public IEnumerable<Payroll> GetAll()
        {
            return DataWorkspace.ApplicationData.Payrolls
                .Select(x => CreateModelPayroll(x))
                .Execute();
        }

        public void Update(Payroll aggregate)
        {
            throw new NotSupportedException();
        }

        public void Insert(Payroll aggregate)
        {
            if (aggregate == null) throw new ArgumentNullException("aggregate");

            var dbPayroll = DataWorkspace.ApplicationData.Payrolls.AddNew();
            dbPayroll.Uid = aggregate.Uid;
            dbPayroll.TimeGenerated = aggregate.TimeGenerated;

            foreach (var payrollItem in aggregate.PayrollItems)
            {
                var dbPayrollItem = dbPayroll.PayrollItems.AddNew();
                dbPayrollItem.Employee = DataWorkspace.ApplicationData.Employees
                    .Where(x => x.Uid == payrollItem.EmployeeUid)
                    .Single();
                dbPayrollItem.GrossPay = payrollItem.GrossPay;
                dbPayrollItem.Deductions = payrollItem.Deductions;
                dbPayrollItem.NetPay = payrollItem.NetPay;
            }
        }

        public void Delete(Payroll aggregate)
        {
            if (aggregate == null) throw new ArgumentNullException("aggregate");

            var dbPayroll = DataWorkspace.ApplicationData.Payrolls
                .Where(x => x.Uid == aggregate.Uid)
                .SingleOrDefault();
            CheckNotNull(dbPayroll);

            dbPayroll.Delete(); //cascade
        }

        public bool PayrollExists(EmployeeUid employeeUid)
        {
            return DataWorkspace.ApplicationData.PayrollItems
                .Where(x => x.Employee.Uid == employeeUid).Count() > 0;
        }

        
    }
}