using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApp.Domain.Model
{
    public class WebAddress: StringValueObject
    {
        protected internal WebAddress(string url)
            : base(url)
        {
        }

        public static WebAddress Create(string url)
        {
            if (url == null) throw new ArgumentNullException("url");
            //TODO - tu regular expr - spr addr
            return new WebAddress(url);
        }

        #region converting

        //TODO = może dodać konwersje wszędzie???

        /*
        public static implicit operator WebAddress(string url)
        {

            return Create(url);
        }
        */

        #endregion
    }
}
