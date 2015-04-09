using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApp.AppServices
{
    public class AddSaleReceiptData
    {
        public Guid EmployeeUid { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }

    public interface IAddSaleReceiptAppService
    {
        Guid Invoke(AddSaleReceiptData args);
    }
}
