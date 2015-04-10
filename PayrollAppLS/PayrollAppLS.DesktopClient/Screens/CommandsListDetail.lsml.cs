using System;
using System.Linq;
using System.IO;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Framework.Client;
using Microsoft.LightSwitch.Presentation;
using Microsoft.LightSwitch.Presentation.Extensions;
namespace LightSwitchApplication
{
    public partial class CommandsListDetail
    {
        partial void Commands_SelectionChanged()
        {
            if (Commands.SelectedItem == null)
            {
                this.FindControl("DTO_AddUpdateOrganization").IsVisible = false;
                this.FindControl("DTO_Delete").IsVisible = false;
                this.FindControl("CommandDetails").IsVisible = false;
                return;
            }

            if (Commands.SelectedItem.DTO_AddUpdateOrganization != null)
            {
                this.FindControl("DTO_AddUpdateOrganization").IsVisible = true;
                this.FindControl("DTO_Delete").IsVisible = false;
                this.FindControl("CommandDetails").IsVisible = true;
                return;
            }

            if (Commands.SelectedItem.DTO_Delete != null)
            {
                this.FindControl("DTO_AddUpdateOrganization").IsVisible = false;
                this.FindControl("DTO_Delete").IsVisible = true;
                this.FindControl("CommandDetails").IsVisible = true;
                return;
            }
        }
    }
}
