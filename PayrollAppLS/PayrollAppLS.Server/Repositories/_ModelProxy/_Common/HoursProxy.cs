using PayrollApp.Domain.Model;

namespace PayrollApp.Infrastructure.Repositories
{
    public class HoursProxy: Hours
    {
        public HoursProxy(double hours) : base(hours)
        {
        }
    }
}