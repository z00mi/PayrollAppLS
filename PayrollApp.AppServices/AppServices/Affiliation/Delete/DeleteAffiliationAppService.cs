using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollApp.Domain.Factories;
using PayrollApp.Domain.Repositories;

namespace PayrollApp.AppServices
{
    public class DeleteAffiliationAppService : IDeleteAffiliationAppService
    {
        private readonly IAffiliationsRepository _affiliationsRepository;
        private readonly IAffiliationValidationSpecificationFactory _validationSpecificationFactory;

        public DeleteAffiliationAppService(
            IAffiliationsRepository affiliationsRepository,
            IAffiliationValidationSpecificationFactory validationSpecificationFactory)
        {
            _affiliationsRepository = affiliationsRepository;
            _validationSpecificationFactory = validationSpecificationFactory;
        }


        public void Invoke(Guid uid)
        {
            var affiliation = _affiliationsRepository.Get(uid);

            affiliation.Delete(_validationSpecificationFactory.GetDeletingValidationSpecification());

            _affiliationsRepository.Delete(affiliation);
            _affiliationsRepository.Save();
        }
    }
}
