using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApp.AppServices
{
    public class AddTimeCardData
    {
        public Guid EmployeeUid { get; set; }
        public DateTime Date { get; set; }
        public double Hours { get; set; }
    }

    public interface IAddTimeCardAppService
    {
        Guid Invoke(AddTimeCardData args);
    }
}
