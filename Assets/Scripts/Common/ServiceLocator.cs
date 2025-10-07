using System;
using System.Collections.Generic;

namespace Platformer.Common
{
    public class ServiceLocator
    {
        public static ServiceLocator Instance
        {
            get
            {
                _instance ??= new ServiceLocator();
                return _instance;
            }
        }

        private static ServiceLocator _instance;
        private readonly Dictionary<Type, object> _instances = new();

        public T Get<T>() where T : class
        {
            return (T)_instances[typeof(T)];
        }

        public void Set<T>(object obj) where T : class
        {
            _instances.Add(typeof(T), obj);
        }
        
        public void Remove<T>() where T : class
        {
            _instances.Remove(typeof(T));
        }
    }
}