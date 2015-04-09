using System;
using LightSwitchApplication;
using PayrollApp.AppServices;

namespace Infrastructure.CommandHandlers
{
    public class UpdatePayrollStatusAssembler
    {
        public static UpdatePayrollStatusData DtoToArgs(DTO_UpdatePayrollStatus dto)
        {
            return new UpdatePayrollStatusData
            {
                PayrollUid = dto.PayrollUid,
                Status = (PayrollStatusData)dto.Status,
                Comment = dto.Comment
            };
        }
    }
}