using PayrollApp.Domain.Model;

namespace PayrollApp.Domain.Repositories
{
    public interface IPayrollsRepository: IRepository<Payroll, PayrollUid>
    {
    }
}
