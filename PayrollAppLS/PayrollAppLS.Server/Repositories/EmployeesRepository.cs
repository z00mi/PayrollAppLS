using System.Collections.ObjectModel;
using System.Linq;
using LightSwitchApplication;
using Microsoft.LightSwitch;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using Address = PayrollApp.Domain.Model.Address;
using DirectMethod = PayrollApp.Domain.Model.DirectMethod;
using Employee = PayrollApp.Domain.Model.Employee;
using HourlyClassification = PayrollApp.Domain.Model.HourlyClassification;
using MailMethod = PayrollApp.Domain.Model.MailMethod;
using SalariedClassification = PayrollApp.Domain.Model.SalariedClassification;

namespace PayrollApp.Infrastructure.Repositories
{
    public class EmployeesRepository: Repository, IEmployeesRepository
    {

        public Employee Get(EmployeeUid uid)
        {
            var dbEmployee = GetOrDefault(uid);
            CheckNotNull(dbEmployee);

            return dbEmployee;
        }

        public Employee GetOrDefault(EmployeeUid uid)
        {
            if (uid == null) throw new ArgumentNullException("uid");

            var dbEmployee = DataWorkspace.ApplicationData.Employees
                .Where(x => x.Uid == uid)
                .SingleOrDefault();
            if (dbEmployee == null)
                return null;

            return CreateModelEmployee(dbEmployee);
        }

        private Employee CreateModelEmployee(LightSwitchApplication.Employee dbEmployee)
        {
            return new EmployeeProxy(
                new EmployeeUidProxy(dbEmployee.Uid),
                new EmployeeHRIdProxy(dbEmployee.HRId), 
                new EmployeeFirstNameProxy(dbEmployee.FirstName),
                new EmployeeLastNameProxy(dbEmployee.LastName),
                dbEmployee.Email != null ? new EmailAddressProxy(dbEmployee.Email) : null,
                dbEmployee.Phone != null ? new PhoneNumberProxy(dbEmployee.Phone) : null,
                dbEmployee.Addresses.Select(address =>
                    new AddressProxy(
                        new AddressCityProxy(address.City),
                        new AddressStreetProxy(address.Street),
                        new AddressNumberProxy(address.Number)
                    )
                ),
                GetPaymentScheduleType(dbEmployee),
                GetPaymentClassification(dbEmployee),
                GetPaymetMethod(dbEmployee)
            );
        }

        private EmployeePaymentScheduleType GetPaymentScheduleType(LightSwitchApplication.Employee employee)
        {
            return (EmployeePaymentScheduleType) employee.PaymentScheduleType;
        }

        private PaymentClassification GetPaymentClassification(LightSwitchApplication.Employee employee)
        {
            switch ((PaymentClassificationType)employee.PaymentClassificationType)
            {
                case PaymentClassificationType.Commisioned:
                    return new CommisionedClassificationProxy(
                        new MoneyProxy(employee.CommisionedClasification.Salary),
                        new CommisionedClassificationCommisionProxy(employee.CommisionedClasification.Commision)
                    );
                case PaymentClassificationType.Hourly:
                    return new HourlyClassificationProxy(
                        new MoneyProxy(employee.HourlyClassification.HourlyRate)
                    );
                case PaymentClassificationType.Salaried:
                    return new SalariedClassificationProxy(
                        new MoneyProxy(employee.SalariedClassification.Salary)
                    );
                default:
                    throw new NotImplementedException();
            }
        }

        private PaymentMethod GetPaymetMethod(LightSwitchApplication.Employee employee)
        {
            switch ((PaymentMethodType)employee.PaymentMethodType)
            {
                case PaymentMethodType.Hold:
                    return new HoldMethodProxy();
                case PaymentMethodType.Direct:
                    return new DirectMethodProxy(
                        new DirectMethodBankProxy(employee.DirectMethod.Bank),
                        new DirectMethodAccountProxy(employee.DirectMethod.Account)
                    );
                case PaymentMethodType.Mail:
                    return new MailMethodProxy(
                        new AddressProxy(
                            new AddressCityProxy(employee.MailMethod.AddressCity),
                            new AddressStreetProxy(employee.MailMethod.AddressStreet),
                            new AddressNumberProxy(employee.MailMethod.AddressNumber)
                        )
                    );
                default:
                    throw new NotImplementedException();
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            return DataWorkspace.ApplicationData.Employees
                .Select(x => CreateModelEmployee(x))
                .Execute();
        }

        public void Update(Employee aggregate)
        {
            if (aggregate == null) throw new ArgumentNullException("aggregate");

            var dbEmployee = DataWorkspace.ApplicationData.Employees
                .Where(x => x.Uid == aggregate.Uid)
                .SingleOrDefault();
            CheckNotNull(dbEmployee);

            dbEmployee.HRId = aggregate.HRId;
            dbEmployee.FirstName = aggregate.FirstName;
            dbEmployee.LastName = aggregate.LastName;
            dbEmployee.Email = aggregate.Email.Value;
            dbEmployee.Phone = aggregate.Phone.Value;

            foreach (var dbAddress in dbEmployee.Addresses)
            {
                dbAddress.Delete();
            }

            foreach (var address in aggregate.Addresses)
            {
                var dbAddress = dbEmployee.Addresses.AddNew();
                dbAddress.City = address.City;
                dbAddress.Street = address.Street;
                dbAddress.Number = address.Number;
            }

            SetPaymentSchedule(dbEmployee, aggregate.PaymentScheduleType);
            SetPaymentClassification(dbEmployee, aggregate.PaymentClassification);
            SetPaymentMethod(dbEmployee, aggregate.PaymentMethod);
        }

        private void SetPaymentSchedule(LightSwitchApplication.Employee employee, EmployeePaymentScheduleType scheduleType)
        {
            employee.PaymentScheduleType = (int)scheduleType;
        }

        private void SetPaymentClassification(LightSwitchApplication.Employee dbEmployee, PaymentClassification paymentClassification)
        {
            if (paymentClassification is CommisionedClassification)
            {
                dbEmployee.PaymentClassificationType = (int)PaymentClassificationType.Commisioned;
                var classification = (CommisionedClassification) paymentClassification;
                dbEmployee.CommisionedClasification = new CommisionedClasification
                {
                    Salary = classification.Salary,
                    Commision = classification.Commision
                };
                return;
            }

            if (paymentClassification is HourlyClassification)
            {
                dbEmployee.PaymentClassificationType = (int)PaymentClassificationType.Hourly;
                var classification = (HourlyClassification)paymentClassification;
                dbEmployee.HourlyClassification = new LightSwitchApplication.HourlyClassification
                {
                    HourlyRate = classification.HourlyRate
                };
                return;
            }

            if (paymentClassification is SalariedClassification)
            {
                dbEmployee.PaymentClassificationType = (int)PaymentClassificationType.Salaried;
                var classification = (SalariedClassification)paymentClassification;
                dbEmployee.SalariedClassification = new LightSwitchApplication.SalariedClassification
                {
                    Salary = classification.Salary
                };
                return;
            }

            throw new NotImplementedException();
        }

        private void SetPaymentMethod(LightSwitchApplication.Employee dbEmployee, PaymentMethod paymentMethod)
        {
            if (paymentMethod is HoldMethod)
            {
                dbEmployee.PaymentMethodType = (int)PaymentMethodType.Hold;
                return;
            }

            if (paymentMethod is DirectMethod)
            {
                dbEmployee.PaymentMethodType = (int)PaymentMethodType.Direct;
                var method = (DirectMethod)paymentMethod;
                dbEmployee.DirectMethod = new LightSwitchApplication.DirectMethod
                {
                    Bank = method.Bank,
                    Account = method.Account
                };
                return;
            }

            if (paymentMethod is MailMethod)
            {
                dbEmployee.PaymentMethodType = (int)PaymentMethodType.Mail;
                var method = (MailMethod)paymentMethod;
                dbEmployee.MailMethod = new LightSwitchApplication.MailMethod
                {
                    AddressCity = method.PaycheckAddress.City,
                    AddressStreet = method.PaycheckAddress.Street,
                    AddressNumber = method.PaycheckAddress.Number
                };
                return;
            }

            throw new NotImplementedException();
        }


        public void Insert(Employee aggregate)
        {
            if (aggregate == null) throw new ArgumentNullException("aggregate");

            var dbEmployee = DataWorkspace.ApplicationData.Employees.AddNew();
            dbEmployee.Uid = aggregate.Uid;
            dbEmployee.FirstName = aggregate.FirstName;
            dbEmployee.LastName = aggregate.LastName;
            dbEmployee.Email = aggregate.Email.Value;
            dbEmployee.Phone = aggregate.Phone.Value;

            foreach (var address in aggregate.Addresses)
            {
                var dbAddress = dbEmployee.Addresses.AddNew();
                dbAddress.City = address.City;
                dbAddress.Street = address.Street;
                dbAddress.Number = address.Number;
            }

            SetPaymentSchedule(dbEmployee, aggregate.PaymentScheduleType);
            SetPaymentClassification(dbEmployee, aggregate.PaymentClassification);
            SetPaymentMethod(dbEmployee, aggregate.PaymentMethod);
        }

        public void Delete(Employee aggregate)
        {
            if (aggregate == null) throw new ArgumentNullException("aggregate");

            var dbEmployee = DataWorkspace.ApplicationData.Employees
                .Where(x => x.Uid == aggregate.Uid)
                .SingleOrDefault();
            CheckNotNull(dbEmployee);

            dbEmployee.Delete(); //cascade
        }

        public bool EmployeeExists(NullableValObj<EmailAddress> employeeEmail, EmployeeUid exceptEmployeeUid)
        {
            if (exceptEmployeeUid != null)
                return DataWorkspace.ApplicationData.Employees
                    .Where(x => x.Uid != exceptEmployeeUid && employeeEmail.HasValue && x.Email == employeeEmail.Value).Count() > 0; 

            return DataWorkspace.ApplicationData.Employees
                .Where(x => employeeEmail.HasValue && x.Email == employeeEmail.Value).Count() > 0; 
        }

        public bool EmployeeExists(EmployeeHRId employeeHRId, EmployeeUid exceptEmployeeUid)
        {
            if (exceptEmployeeUid != null)
                return DataWorkspace.ApplicationData.Employees
                    .Where(x => x.Uid != exceptEmployeeUid && x.HRId == employeeHRId).Count() > 0;

            return DataWorkspace.ApplicationData.Employees
                .Where(x => x.HRId == employeeHRId).Count() > 0;
        }


        public bool EmployeeExists(NullableValObj<PhoneNumber> employeePhone, EmployeeUid exceptEmployeeUid)
        {
            if (exceptEmployeeUid != null)
                return DataWorkspace.ApplicationData.Employees
                    .Where(x => x.Uid != exceptEmployeeUid && employeePhone.HasValue && x.Email == employeePhone.Value).Count() > 0;

            return DataWorkspace.ApplicationData.Employees
                .Where(x => employeePhone.HasValue && x.Email == employeePhone.Value).Count() > 0; 
        }
    }
}