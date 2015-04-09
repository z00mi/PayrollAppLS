using System;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;

namespace PayrollApp.Domain.Sepcifications
{
    public class TimeCardDeletingValidationSpecyfication : ValidationSpecification<TimeCard>
    {
        private readonly ITimeCardsRepository _timeCardsRepository;

        public TimeCardDeletingValidationSpecyfication(ITimeCardsRepository timeCardsRepository)
        {
            _timeCardsRepository = timeCardsRepository;
        }

        public override bool IsSatisfiedBy(TimeCard o, ref string failedMessages)
        {
            //return 
            //    _emailNotExists
            //    .And(_employeeFirstAndLastNameNotExists)
            //    .IsSatisfiedBy(o, ref failedMessages);

            return true;
        }
    }
}
