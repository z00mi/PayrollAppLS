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
    public class DeleteTimeCardAppService : IDeleteTimeCardAppService
    {
        private readonly ITimeCardsRepository _timeCardsRepository;
        private readonly ITimeCardValidationSpecificationFactory _validationSpecificationFactory;

        public DeleteTimeCardAppService(
            ITimeCardsRepository timeCardsRepository,
            ITimeCardValidationSpecificationFactory validationSpecificationFactory)
        {
            _timeCardsRepository = timeCardsRepository;
            _validationSpecificationFactory = validationSpecificationFactory;
        }

        public void Invoke(Guid uid)
        {
            var timeCard = _timeCardsRepository.Get(uid);

            timeCard.Delete(_validationSpecificationFactory.GetDeletingValidationSpecification());

            _timeCardsRepository.Delete(timeCard);
            _timeCardsRepository.Save();
        }
    }
}
