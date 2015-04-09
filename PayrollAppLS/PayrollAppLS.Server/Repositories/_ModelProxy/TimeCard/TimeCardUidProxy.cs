using System;
using PayrollApp.Domain.Model;

namespace PayrollApp.Infrastructure.Repositories
{
    public class TimeCardUidProxy: TimeCardUid
    {
        public TimeCardUidProxy(Guid uid) : base(uid)
        {
        }
    }
}