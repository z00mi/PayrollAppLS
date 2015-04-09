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
    public class AddTimeCardAppService : IAddTimeCardAppService
    {
        private readonly ITimeCardsRepository _timeCardsRepository;
        private readonly ITimeCardValidationSpecificationFactory _validationSpecificationFactory;

        public AddTimeCardAppService(
            ITimeCardsRepository timeCardsRepository,
            ITimeCardValidationSpecificationFactory validationSpecificationFactory)
        {
            _timeCardsRepository = timeCardsRepository;
            _validationSpecificationFactory = validationSpecificationFactory;
        }

        public Guid Invoke(AddTimeCardData args)
        {
            var newTimeCard = TimeCard.Create(
                args.EmployeeUid,
                args.Date,
                args.Hours,
                _validationSpecificationFactory.GetCreatingValidationSpecification());

            _timeCardsRepository.Insert(newTimeCard);
            _timeCardsRepository.Save();

            return newTimeCard.Uid;
        }
    }
}
