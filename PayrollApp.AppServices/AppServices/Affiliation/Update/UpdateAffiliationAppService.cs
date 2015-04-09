using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollApp.Domain.Factories;
using PayrollApp.Domain.Repositories;

namespace PayrollApp.AppServices
{
    public class UpdateAffiliationAppService : IUpdateAffiliationAppService
    {
        private readonly IAffiliationsRepository _affiliationsRepository;
        private readonly IAffiliationValidationSpecificationFactory _validationSpecificationFactory;

        public UpdateAffiliationAppService(
            IAffiliationsRepository affiliationsRepository,
            IAffiliationValidationSpecificationFactory validationSpecificationFactory)
        {
            _affiliationsRepository = affiliationsRepository;
            _validationSpecificationFactory = validationSpecificationFactory;
        }

        public void Invoke(UpdateAffiliationData args)
        {
            var affiliation = _affiliationsRepository.Get(args.AffiliationUid);

            affiliation.Update(
                args.Dues,
                args.MemberId,
                _validationSpecificationFactory.GetUpdatingValidationSpecification());

            _affiliationsRepository.Update(affiliation);
            _affiliationsRepository.Save();
        }
    }
}
