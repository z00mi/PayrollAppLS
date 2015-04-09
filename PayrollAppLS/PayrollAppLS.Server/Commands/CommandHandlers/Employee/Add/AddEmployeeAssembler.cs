using System;
using System.Collections.Generic;
using System.Linq;
using LightSwitchApplication;
using Microsoft.Data.OData.Query.SemanticAst;
using Microsoft.LightSwitch.Framework;
using PayrollApp.AppServices;

namespace Infrastructure.CommandHandlers
{
    public class AddEmployeeAssembler
    {
        public static AddEmployeeData DtoToArgs(DTO_AddUpdateEmployee dto)
        {
            var employeeData = new AddEmployeeData
            {
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


        #region protected

        protected static IEnumerable<AddressData> AddressesDtoToCollection(EntityCollection<DTO_Address> dtoCollection)
        {
            return dtoCollection.Select(x => new AddressData
            {
                City = x.City,
                Street = x.Street,
                Number = x.Number
            });
        }

        protected static PaymentScheduleTypeData PaymentScheduleTypeDtoToVal(int dtoValue)
        {
            if (dtoValue < (int)PaymentScheduleTypeData.Weekly || dtoValue > (int)PaymentScheduleTypeData.Monthly)
                throw new ArgumentOutOfRangeException("dtoValue");

            return (PaymentScheduleTypeData)dtoValue;
        }

        protected static PaymentMethodData PaymentMethodDtoToVal(DTO_AddUpdateEmployee dto)
        {
            switch (dto.PaymentMethodType)
            {
                case 1:
                    return new PaymentHoldMethodData();
                case 2:
                    return new PaymentDirectMethodData()
                    {
                        Bank = dto.PayDirectMethod_Bank,
                        Account = dto.PayDirectMethod_Account
                    };
                case 3:
                    return new PaymentMailMethodData()
                    {
                        PaycheckAddress = new AddressData
                        {
                            City = dto.PayMailMethod_City,
                            Street = dto.PayMailMethod_Street,
                            Number = dto.PayMailMethod_Number
                        }
                    };
                default:
                    throw new NotSupportedException();
            }
        }

        protected static PaymentClassificationData PaymentClassificationDtoToVal(DTO_AddUpdateEmployee dto)
        {
            switch (dto.PaymentClassificationType)
            {
                case 1:
                    return new PaymentCommisionedClassification()
                    {
                        Salary = dto.PayCommisionedClassification_Salary.Value,
                        Commision = dto.PayCommisionedClassification_Commision.Value
                    };
                case 2:
                    return new PaymentHourlyClassification()
                    {
                        HourlyRate = dto.PayHourlyClassification_HourlyRate.Value
                    };
                case 3:
                    return new PaymentSalariedClassification()
                    {
                        Salary = dto.PaySalariedClassification_Salary.Value
                    };
                default:
                    throw new NotSupportedException();
            }
        }

        #endregion 
    }
}