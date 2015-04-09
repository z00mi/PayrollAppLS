using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApp.AppServices
{
    public class AddAffiliationData
    {
        public Guid EmployeeUid { get; set; }
        public Guid OrganizationUid { get; set; }
        public string MemberId { get; set; }
        public decimal Dues { get; set; }
    }

    public interface IAddAffiliationAppService
    {
        Guid Invoke(AddAffiliationData args);
    }
}
