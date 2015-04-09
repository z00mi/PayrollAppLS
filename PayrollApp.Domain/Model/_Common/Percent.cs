using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApp.Domain.Model
{
    public class Percent : DecimalValueObject
    {
        protected Percent(decimal percent) : base(percent)
        {
        }

        public static Percent Create(decimal percent)
        {
            //TODO ograniczenie na procent? 
            return new Percent(percent);
        }
    }
}
