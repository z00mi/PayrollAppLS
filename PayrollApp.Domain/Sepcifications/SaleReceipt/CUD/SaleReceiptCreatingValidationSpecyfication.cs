using System;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;

namespace PayrollApp.Domain.Sepcifications
{
    public class SaleReceiptCreatingValidationSpecyfication : ValidationSpecification<SaleReceipt>
    {
        private readonly ISaleReceiptsRepository _saleReceiptsRepository;

        public SaleReceiptCreatingValidationSpecyfication(ISaleReceiptsRepository saleReceiptsRepository)
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
