using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApp.AppServices
{
    public class UpdatePayrollStatusData
    {
        public Guid PayrollUid { get; set; }
        public PayrollStatusData Status { get; set; }
        public string Comment { get; set; }
    }

    public enum PayrollStatusData
    {
        Generated = 1,
        Rejected = 2,
        Accepted = 3,
        PaymentPerformed = 4
    }


    public interface IUpdatePayrollStatusAppService
    {
        void Invoke(UpdatePayrollStatusData args);
    }
}
