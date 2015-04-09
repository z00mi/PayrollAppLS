using System.Linq;
using Microsoft.LightSwitch;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace PayrollApp.Infrastructure.Repositories
{
    public class SaleReceiptsRepository: Repository, ISaleReceiptsRepository
    {

        public SaleReceipt Get(SaleReceiptUid uid)
        {
            var dbSaleReceipt = GetOrDefault(uid);
            CheckNotNull(dbSaleReceipt);

            return dbSaleReceipt;
        }

        public SaleReceipt GetOrDefault(SaleReceiptUid uid)
        {
            if (uid == null) throw new ArgumentNullException("uid");

            var dbSaleReceipt = DataWorkspace.ApplicationData.SaleReceipts
                .Where(x => x.Uid == uid)
                .SingleOrDefault();
            if (dbSaleReceipt == null)
                return null;

            return CreateModelSaleReceipt(dbSaleReceipt);
        }

        public IEnumerable<SaleReceipt> GetAll()
        {
            return DataWorkspace.ApplicationData.SaleReceipts
                .Select(x => CreateModelSaleReceipt(x))
                .Execute();
        }

        public void Update(SaleReceipt aggregate)
        {
            if (aggregate == null) throw new ArgumentNullException("aggregate");

            var dbSaleReceipt = DataWorkspace.ApplicationData.SaleReceipts
                .Where(x => x.Uid == aggregate.Uid)
                .SingleOrDefault();
            CheckNotNull(dbSaleReceipt);

            dbSaleReceipt.SRDate = aggregate.Date;
            dbSaleReceipt.Amount = aggregate.Amount;
        }

        public void Insert(SaleReceipt aggregate)
        {
            if (aggregate == null) throw new ArgumentNullException("aggregate");

            var dbSaleReceipt = DataWorkspace.ApplicationData.SaleReceipts.AddNew();
            dbSaleReceipt.Uid = aggregate.Uid;
            dbSaleReceipt.Employee = DataWorkspace.ApplicationData.Employees
                .Where(x => x.Uid == aggregate.EmployeeUid)
                .Single();
            dbSaleReceipt.SRDate = aggregate.Date;
            dbSaleReceipt.Amount = aggregate.Amount;
        }

        public void Delete(SaleReceipt aggregate)
        {
            if (aggregate == null) throw new ArgumentNullException("aggregate");

            var dbSaleReceipt = DataWorkspace.ApplicationData.SaleReceipts
                .Where(x => x.Uid == aggregate.Uid)
                .SingleOrDefault();
            CheckNotNull(dbSaleReceipt);

            dbSaleReceipt.Delete();
        }

        private SaleReceipt CreateModelSaleReceipt(LightSwitchApplication.SaleReceipt dbSaleReceipt)
        {
            return new SaleReceiptProxy(
                new SaleReceiptUidProxy(dbSaleReceipt.Uid),
                new EmployeeUidProxy(dbSaleReceipt.Employee.Uid),
                new DateProxy(dbSaleReceipt.SRDate),
                new MoneyProxy(dbSaleReceipt.Amount)
            );           
        }
    }
}