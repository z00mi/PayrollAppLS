﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayrollApp.Domain.Model;

namespace PayrollApp.Infrastructure.Repositories
{
    public class DirectMethodProxy : DirectMethod
    {
        public DirectMethodProxy(DirectMethodBank bank, DirectMethodAccount account) : base(bank, account)
        {
        }
    }
}