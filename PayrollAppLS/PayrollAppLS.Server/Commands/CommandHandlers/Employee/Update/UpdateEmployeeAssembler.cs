using System;
using LightSwitchApplication;
using PayrollApp.AppServices;

namespace Infrastructure.CommandHandlers
{
    public class UpdateEmployeeAssembler: AddEmployeeAssembler
    {
        public static UpdateEmployeeData DtoToArgs(DTO_AddUpdateEmployee dto)
        {
            var employeeData = new UpdateEmployeeData
            {
                EmployeeUid = dto.EmployeeUid.Value,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                Address = AddressesDtoToCollection(dto.Addresses),
                PaymentScheduleType = PaymentScheduleTypeDtoToVal(dto.PaymentScheduleType),
                PaymentClassification = PaymentClassificationDtoToVal(dto),
                PaymentMethod = PaymentMethodDtoToVal(dto)
            };

            return employeeData;
        }
    }
}