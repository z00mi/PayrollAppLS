using System;
using System.Collections;
using System.Collections.Generic;
using StructureMap;

namespace PayrollApp.Infrastructure.IoC
{
    public class DependencyProvider : IDependencyProvider
    {
        public static IDependencyProvider Instance = new DependencyProvider();

        public T GetInstance<T>()
        {
            return ObjectFactory.Container.GetInstance<T>();
        }

        public object GetInstance(Type dependencyType)
        {
            return ObjectFactory.Container.GetInstance(dependencyType);
        }

        public IEnumerable<T> GetAllInstances<T>()
        {
            return ObjectFactory.Container.GetAllInstances<T>();
        }

        public IEnumerable GetAllInstances(Type type)
        {
            return ObjectFactory.Container.GetAllInstances(type);
        }
    }
}