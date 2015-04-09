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
    public class AddServiceChargeAppService : IAddServiceChargeAppService
    {
        private readonly IServiceChargesRepository _serviceChargesRepository;
        private readonly IAffiliationsRepository _affiliationsRepository;
        private readonly IServiceChargeValidationSpecificationFactory _validationSpecificationFactory;

        public AddServiceChargeAppService(
            IServiceChargesRepository serviceChargesRepository,
            IAffiliationsRepository affiliationsRepository,
            IServiceChargeValidationSpecificationFactory validationSpecificationFactory)
        {
            _serviceChargesRepository = serviceChargesRepository;
            _affiliationsRepository = affiliationsRepository;
            _validationSpecificationFactory = validationSpecificationFactory;
        }

        public Guid Invoke(AddServiceChargeData args)
        {
            Affiliation affiliation = _affiliationsRepository.GetBy(args.OrganizationUid, args.MemberId);

            var newServiceCharge = ServiceCharge.Create(
                affiliation.Uid,
                args.Date,
                args.Amount,
                _validationSpecificationFactory.GetCreatingValidationSpecification());

            _serviceChargesRepository.Insert(newServiceCharge);
            _serviceChargesRepository.Save();

            return newServiceCharge.Uid;
        }
    }
}
