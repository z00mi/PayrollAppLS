using System;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;

namespace PayrollApp.Domain.Sepcifications
{
    public class SaleReceiptDeletingValidationSpecyfication : ValidationSpecification<SaleReceipt>
    {
        private readonly ISaleReceiptsRepository _saleReceiptsRepository;

        public SaleReceiptDeletingValidationSpecyfication(ISaleReceiptsRepository saleReceiptsRepository)
        {
            _saleReceiptsRepository = saleReceiptsRepository;
        }

        public override bool IsSatisfiedBy(SaleReceipt o, ref string failedMessages)
        {
            //return 
            //    _emailNotExists
            //    .And(_employeeFirstAndLastNameNotExists)
            //    .IsSatisfiedBy(o, ref failedMessages);

            return true;
        }
    }
}
