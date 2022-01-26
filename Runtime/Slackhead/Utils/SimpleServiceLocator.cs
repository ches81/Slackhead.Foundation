using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Slackhead.Utils
{
    [UsedImplicitly]
    public class SimpleServiceLocator
    {
        private readonly Dictionary<object, object> serviceContainer;


        public SimpleServiceLocator()
        {
            serviceContainer = new Dictionary<object, object>();
        }


        public T Get<T>()
        {
            try
            {
                return (T) serviceContainer[typeof(T)];
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Service not available.");
            }
        }


        public void Add<T>(T service)
        {
            if (service == null)
            {
                throw new NullReferenceException("Service must not be null!");
            }

            Type type = typeof(T);
            if (!serviceContainer.ContainsKey(type))
            {
                serviceContainer.Add(type, service);
            }
            else
            {
                Debug.LogWarning("Service has already been added to ServiceLocator.");
            }
        }
    }
}