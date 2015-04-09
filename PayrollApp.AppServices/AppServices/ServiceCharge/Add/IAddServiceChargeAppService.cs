using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollApp.Domain.Model;

namespace PayrollApp.AppServices
{
    public class AddServiceChargeData
    {
        public Guid OrganizationUid { get; set; }
        public string MemberId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }

    public interface IAddServiceChargeAppService
    {
        Guid Invoke(AddServiceChargeData args);
    }
}
