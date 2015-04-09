using System;
using System.Linq;
using System.Collections.Generic;
using LightSwitchApplication.UserCode;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Presentation.Extensions;
namespace LightSwitchApplication
{
    public partial class OrganizationsListDetail
    {

        partial void OrganizationsListDetail_InitializeDataWorkspace(List<IDataService> saveChangesTo)
        {
            this.HideModalCloseButton("AddOrganization");
            this.SuprresEnterKeyForUnderlyingControls(new[] { "AddOrganizationName", "AddOrganizationWebAddress", "AddOrganizationConfirm", "AddOrganizationCancel" });

            this.HideModalCloseButton("EditOrganization");
            this.SuprresEnterKeyForUnderlyingControls(new[] { "EditOrganizationName", "EditOrganizationWebAddress", "EditOrganizationConfirm", "EditOrganizationCancel" });
        }

        partial void OrganizationsListDetail_SaveError(Exception exception, ref bool handled)
        {
            ErrorHandler.Handle(this, exception);
        }


        #region Add Organization

        partial void OrganizationListAddAndEditNew_CanExecute(ref bool result)
        {
            result = Application.User.HasPermission(Permissions.CanAddOrganizations);
        }

        partial void OrganizationListAddAndEditNew_Execute()
        {
            DTO_AddUpdateOrganization = Application.CommandFactory.CreateAddOrganizationCommandDTO();
            this.OpenModalWindow("AddOrganization");
        }

        partial void AddOrganizationConfirm_Execute()
        {
            try
            {
                Save();
            }
            catch
            {
                return;
            }
            this.CloseModalWindow("AddOrganization");

            RefreshAndSelectRowAfterAddNew(DTO_AddUpdateOrganization.OrganizationUid);

            DTO_AddUpdateOrganization = null;
        }

        partial void AddOrganizationCancel_Execute()
        {
            this.CloseModalWindow("AddOrganization");

            DTO_AddUpdateOrganization.Command.Cancel();
            DTO_AddUpdateOrganization = null;
        }

        private void RefreshAndSelectRowAfterAddNew(Guid? uid)
        {
            Organizations.Load();
            Organizations.Refresh();
            Organizations.Details.PageNumber = Organizations.Details.PageCount;

            Organizations.SelectedItem = Organizations.FirstOrDefault(item => item.Uid == uid);
        }

        #endregion


        #region Edit Organization

        partial void OrganizationListEditSelected_CanExecute(ref bool result)
        {
            result = Organizations.SelectedItem != null && Application.User.HasPermission(Permissions.CanUpdateOrganizations);
        }

        partial void OrganizationListEditSelected_Execute()
        {
            var organizationData = OrganizationByUid; //invoke query OrganizationByUid(Organizations.SelectedItem.Uid)

            DTO_AddUpdateOrganization = Application.CommandFactory.CreateUpdateOrganizationCommandDTO(organizationData);

            this.OpenModalWindow("EditOrganization");
        }

        partial void EditOrganizationConfirmMethod_Execute()
        {
            try
            {
                Save();
            }
            catch
            {
                return;
            }
            this.CloseModalWindow("EditOrganization");

            RefreshAndSelectRowAfterEdit(DTO_AddUpdateOrganization.OrganizationUid);

            DTO_AddUpdateOrganization = null;
        }

        partial void EditOrganizationCancelMethod_Execute()
        {
            this.CloseModalWindow("EditOrganization");

            DTO_AddUpdateOrganization.Command.Cancel();
            DTO_AddUpdateOrganization = null;
        }

        private void RefreshAndSelectRowAfterEdit(Guid? uid)
        {
            Organizations.Refresh();
            Organizations.SelectedItem = Organizations.FirstOrDefault(item => item.Uid == uid);
        }

        #endregion


        #region Delete Organization

        partial void OrganizationListDeleteSelected_CanExecute(ref bool result)
        {
            result = Organizations.SelectedItem != null && Application.User.HasPermission(Permissions.CanDeleteOrganizations);
        }

        partial void OrganizationListDeleteSelected_Execute()
        {
            System.Windows.MessageBoxResult result =
                this.ShowMessageBox(
                    "Are you sure that you want to delete " + Organizations.SelectedItem.Name + " ?",
                    "Delete Confirm",
                    MessageBoxOption.YesNo);

            if (result != System.Windows.MessageBoxResult.Yes)
                return;

            DTO_Delete = Application.CommandFactory.CreateDeleteOrganizationCommandDTO(Organizations.SelectedItem.Uid);

            try
            {
                var pageNumber = Organizations.Details.PageNumber;

                DTO_Delete.Command.Invoke();

                RefreshAndSelectPageAfterDelete(pageNumber);
            }
            finally
            {
                DTO_Delete = null;
            }
        }

        public void RefreshAndSelectPageAfterDelete(int pageNumber)
        {
            Organizations.Load();
            Organizations.Refresh();
            if (Organizations.Details.PageCount > 0)
                Organizations.Details.PageNumber = Organizations.Details.PageCount < pageNumber ? pageNumber - 1 : pageNumber;
        }

        #endregion

    }
    
}
