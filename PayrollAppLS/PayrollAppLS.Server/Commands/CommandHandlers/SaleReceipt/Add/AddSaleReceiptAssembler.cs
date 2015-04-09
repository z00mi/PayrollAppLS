using System;
using LightSwitchApplication;
using PayrollApp.AppServices;

namespace Infrastructure.CommandHandlers
{
    public class AddSaleReceiptAssembler
    {
        public static AddSaleReceiptData DtoToArgs(DTO_AddSaleReceipt dto)
        {
            return new AddSaleReceiptData
            {
                EmployeeUid = dto.EmployeeUid,
                Date = dto.SRDate,
                Amount = dto.Amount
            };
        }
    }
}