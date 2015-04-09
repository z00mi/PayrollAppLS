using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollApp.Domain.Factories;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;

namespace PayrollApp.AppServices
{
    public class AddSaleReceiptAppService : IAddSaleReceiptAppService
    {
        private readonly ISaleReceiptsRepository _saleReceiptsRepository;
        private readonly ISaleReceiptValidationSpecificationFactory _validationSpecificationFactory;

        public AddSaleReceiptAppService(
            ISaleReceiptsRepository saleReceiptsRepository,
            ISaleReceiptValidationSpecificationFactory validationSpecificationFactory)
        {
            _saleReceiptsRepository = saleReceiptsRepository;
            _validationSpecificationFactory = validationSpecificationFactory;
        }

        public Guid Invoke(AddSaleReceiptData args)
        {
            var newSaleReceipt = SaleReceipt.Create(
                args.EmployeeUid,
                args.Date,
                args.Amount,
                _validationSpecificationFactory.GetCreatingValidationSpecification());

            _saleReceiptsRepository.Insert(newSaleReceipt);
            _saleReceiptsRepository.Save();

            return newSaleReceipt.Uid;
        }
    }
}
