using PayrollApp.Domain.Model;

namespace PayrollApp.Infrastructure.Repositories
{
    public class TimeCardProxy: TimeCard
    {
        public TimeCardProxy(TimeCardUid uid, EmployeeUid employeeUid, Date date, Hours hours) : base(uid, employeeUid, date, hours)
        {
        }
    }
}