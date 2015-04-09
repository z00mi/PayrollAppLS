using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollApp.Domain.Exceptions;
using PayrollApp.Domain.Factories;
using PayrollApp.Domain.Repositories;

namespace PayrollApp.AppServices
{
    public class DeleteSaleReceiptAppService : IDeleteSaleReceiptAppService
    {
        private readonly ISaleReceiptsRepository _saleReceiptsRepository;
        private readonly ISaleReceiptValidationSpecificationFactory _validationSpecificationFactory;

        public DeleteSaleReceiptAppService(
            ISaleReceiptsRepository saleReceiptsRepository,
            ISaleReceiptValidationSpecificationFactory validationSpecificationFactory)
        {
            _saleReceiptsRepository = saleReceiptsRepository;
            _validationSpecificationFactory = validationSpecificationFactory;
        }

        public void Invoke(Guid uid)
        {
            var saleReceipt = _saleReceiptsRepository.Get(uid);

            saleReceipt.Delete(_validationSpecificationFactory.GetDeletingValidationSpecification());

            _saleReceiptsRepository.Delete(saleReceipt);
            _saleReceiptsRepository.Save();
        }
    }
}
