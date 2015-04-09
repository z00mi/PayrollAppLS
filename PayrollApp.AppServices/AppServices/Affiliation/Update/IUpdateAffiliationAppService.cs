using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApp.AppServices
{
    public class UpdateAffiliationData
    {
        public Guid AffiliationUid { get; set; }
        public string MemberId { get; set; }
        public decimal Dues { get; set; }
    }

    public interface IUpdateAffiliationAppService
    {
        void Invoke(UpdateAffiliationData args);
    }
}
