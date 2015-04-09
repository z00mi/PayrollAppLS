using System;
using LightSwitchApplication;
using PayrollApp.AppServices;

namespace Infrastructure.CommandHandlers
{
    public class AddTimeCardAssembler
    {
        public static AddTimeCardData DtoToArgs(DTO_AddTimeCard dto)
        {
            return new AddTimeCardData
            {
                EmployeeUid = dto.EmployeeUid,
                Date = dto.TCDate,
                Hours = dto.Hours
            };
        }
    }
}