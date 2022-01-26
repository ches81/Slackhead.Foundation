using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JetBrains.Annotations;
using Slackhead.ReactiveProperties;
using UnityEngine;

namespace Slackhead.MVVM
{
    public abstract class ViewModel
    {
        /// <summary>
        /// Cache for all reactive properties.
        /// </summary>
        private readonly Dictionary<string, object> reactiveProperties = new Dictionary<string, object>();

        private readonly Dictionary<object, string> reactiveProperties2 = new Dictionary<object, string>();

        public event Action<object> OnValueChanged;


        /// <summary>
        /// Sets the properties value to the reactive property.
        /// If a reactive property for a property does not exist a new one is created and added to the cache.
        /// </summary>
        /// <param name="property"></param>
        /// <param name="val"></param>
        /// <param name="labelName"></param>
        /// <typeparam name="T"></typeparam>
        [PublicAPI]
        public void Set<T>(ref T property, T val, string name)
        {
            if (!reactiveProperties.TryGetValue(name, out var cachedProperty))
            {
                var newProperty = new ReactiveProperty<T>();
                newProperty.Set(val);
                newProperty.OnValueChanged += OnChildPropertyValueChanged;
                reactiveProperties.Add(name, newProperty);
                reactiveProperties2.Add(newProperty, name);
            }

            var typedProperty = (ReactiveProperty<T>) cachedProperty;
            typedProperty?.Set(val);
        }


        private void OnChildPropertyValueChanged<T>(T obj)
        {
            OnValueChanged?.Invoke(obj);
        }


        public T GetValue<T>(string propertyName)
        {
            return (T) reactiveProperties[propertyName];
        }


        public void Bind(Func<string, int> memberExpression)
        {
            Debug.Log(memberExpression.Invoke("blub"));
        }
    }
}