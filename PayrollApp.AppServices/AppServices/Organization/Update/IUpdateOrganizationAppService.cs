using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApp.AppServices
{
    public class UpdateOrganizationData : AddOrganizationData
    {
        public Guid OrganizationUid { get; set; }
    }

    public interface IUpdateOrganizationAppService
    {
        void Invoke(UpdateOrganizationData args);
    }
}
