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
    public class TimeCardValidationSpecificationFactory : ITimeCardValidationSpecificationFactory
    {
        private readonly ITimeCardsRepository _timeCardsRepository;

        public TimeCardValidationSpecificationFactory(ITimeCardsRepository timeCardsRepository)
        {
            _timeCardsRepository = timeCardsRepository;
        }

        public IValidationSpecification<TimeCard> GetCreatingValidationSpecification()
        {
            return new TimeCardCreatingValidationSpecyfication(_timeCardsRepository);
        }

        public IValidationSpecification<TimeCard> GetDeletingValidationSpecification()
        {
            return new TimeCardDeletingValidationSpecyfication(_timeCardsRepository);
        }
    }
}
