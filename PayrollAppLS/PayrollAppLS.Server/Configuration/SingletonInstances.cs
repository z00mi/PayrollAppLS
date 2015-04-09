using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Services;
using PayrollApp.Infrastructure.IoC;

namespace PayrollApp.Infrastructure.Configuration
{
    public class SingletonInstances
    {
        public static void Initialize()
        {
            AggregateRoot.InitEventsPublisher(DependencyProvider.Instance.GetInstance<IDomainEventsPublisher>());
        }
    }
}