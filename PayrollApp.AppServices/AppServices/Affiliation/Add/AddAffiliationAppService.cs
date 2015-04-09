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
    public class AddAffiliationAppService : IAddAffiliationAppService
    {
        private readonly IAffiliationsRepository _affiliationsRepository;
        private readonly IAffiliationValidationSpecificationFactory _validationSpecificationFactory;

        public AddAffiliationAppService(
            IAffiliationsRepository affiliationsRepository,
            IAffiliationValidationSpecificationFactory validationSpecificationFactory)
        {
            _affiliationsRepository = affiliationsRepository;
            _validationSpecificationFactory = validationSpecificationFactory;
        }

        public Guid Invoke(AddAffiliationData args)
        {
            var newAffiliation = Affiliation.Create(
                args.EmployeeUid,
                args.OrganizationUid,
                args.MemberId,
                args.Dues,
                _validationSpecificationFactory.GetCreatingValidationSpecification());

            _affiliationsRepository.Insert(newAffiliation);
            _affiliationsRepository.Save();

            return newAffiliation.Uid;
        }
    }
}
