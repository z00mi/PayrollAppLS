﻿using System;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;

namespace PayrollApp.Domain.Sepcifications
{
    public class ServiceChargeDeletingValidationSpecyfication : ValidationSpecification<ServiceCharge>
    {
        private readonly IServiceChargesRepository _serviceChargesRepository;

        public ServiceChargeDeletingValidationSpecyfication(IServiceChargesRepository serviceChargesRepository)
        {
            _serviceChargesRepository = serviceChargesRepository;
        }

        public override bool IsSatisfiedBy(ServiceCharge o, ref string failedMessages)
        {
            //return 
            //    _emailNotExists
            //    .And(_employeeFirstAndLastNameNotExists)
            //    .IsSatisfiedBy(o, ref failedMessages);

            return true;
        }
    }
}
