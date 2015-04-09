﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayrollApp.Domain.Model;

namespace PayrollApp.Infrastructure.Repositories
{
    public class AffiliationUidProxy : AffiliationUid
    {
        public AffiliationUidProxy(Guid uid) : base(uid)
        {
        }
    }
}