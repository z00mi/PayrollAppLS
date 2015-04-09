using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApp.AppServices
{
    public class UpdateEmployeeData : AddEmployeeData
    {
        public Guid EmployeeUid { get; set; }
    }

    public interface IUpdateEmployeeAppService
    {
        void Invoke(UpdateEmployeeData args);
    }
}
