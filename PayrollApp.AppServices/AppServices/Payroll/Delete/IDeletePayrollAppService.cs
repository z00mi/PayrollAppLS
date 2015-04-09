using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApp.AppServices
{
    public interface IDeletePayrollAppService
    {
        void Invoke(Guid uid);
    }
}
