using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollApp.Domain.Model;

namespace PayrollApp.AppServices
{
    public interface IGeneratePayrollAppService
    {
        Guid Invoke(DateTime forDate);
    }
}
