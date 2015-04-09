using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;
using PayrollApp.Domain.Sepcifications;

namespace PayrollApp.Domain.Factories
{
    public class SaleReceiptValidationSpecificationFactory : ISaleReceiptValidationSpecificationFactory
    {
        private readonly ISaleReceiptsRepository _saleReceiptsRepository;

        public SaleReceiptValidationSpecificationFactory(ISaleReceiptsRepository saleReceiptsRepository)
        {
            _saleReceiptsRepository = saleReceiptsRepository;
        }

        public IValidationSpecification<SaleReceipt> GetCreatingValidationSpecification()
        {
            return new SaleReceiptCreatingValidationSpecyfication(_saleReceiptsRepository);
        }

        public IValidationSpecification<SaleReceipt> GetDeletingValidationSpecification()
        {
            return new SaleReceiptDeletingValidationSpecyfication(_saleReceiptsRepository);
        }
    }
}
