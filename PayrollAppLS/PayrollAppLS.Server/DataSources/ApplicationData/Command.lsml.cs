using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.LightSwitch;
namespace LightSwitchApplication
{
    public partial class Command
    {
        public void Cancel()
        {
            this.Details.EntitySet.Details.DataService.Details.DiscardChanges();
        }

        public void Invoke()
        {
            this.Details.EntitySet.Details.DataService.SaveChanges();
        }
    }
}
