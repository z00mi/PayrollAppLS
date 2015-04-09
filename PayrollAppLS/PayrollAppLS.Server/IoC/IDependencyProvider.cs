using System;
using System.Collections;
using System.Collections.Generic;

namespace PayrollApp.Infrastructure.IoC
{
    public interface IDependencyProvider
    {
        T GetInstance<T>();
        object GetInstance(Type dependencyType);
        IEnumerable<T> GetAllInstances<T>();
        IEnumerable GetAllInstances(Type type);
    }
}