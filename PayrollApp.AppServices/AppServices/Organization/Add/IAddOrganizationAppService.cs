using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApp.AppServices
{
    public class AddOrganizationData
    {
        public string Name { get; set; }
        public string WebAddress { get; set; }
    }

    public interface IAddOrganizationAppService
    {
        Guid Invoke(AddOrganizationData args);
    }
}
