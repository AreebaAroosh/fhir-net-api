﻿#if USE_CODE_GEN

/*
 * This code is based on the article by Mariano Omar Rodiguez found here: 
 * http://weblogs.asp.net/marianor/archive/2009/04/10/using-expression-trees-to-get-property-getter-and-setters.aspx
 */

using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Hl7.Fhir.Introspection
{
    internal static class PropertyInfoExtensions
    {
        public static Func<T, object> GetValueGetter<T>(this PropertyInfo propertyInfo)
        {
            if (typeof(T) != propertyInfo.DeclaringType)
                throw new ArgumentException("Generic param T must agree with the declaring type of the property.", nameof(propertyInfo));

            return (Func<T, object>)buildGetter(propertyInfo, typeof(T));
        }


        public static Func<object, object> GetValueGetter(this PropertyInfo propertyInfo)
        {
            return (Func<object, object>)buildGetter(propertyInfo, typeof(object));
        }

        private static Delegate buildGetter(PropertyInfo propertyInfo, Type instanceType)
        {
            var instance = Expression.Parameter(instanceType, "i");    // get(instanceType i) =>

            Expression convertedInstance = instanceType == typeof(object) ?
                    (Expression)Expression.Convert(instance, propertyInfo.DeclaringType) :    // var p = (declaringType)i
                    (Expression)instance;

            var property = Expression.Property(convertedInstance, propertyInfo);   // var q = p.<property>
            var convertOut = Expression.TypeAs(property, typeof(object)); // var result = q as object

            return Expression.Lambda(convertOut, instance).Compile();
        }

        public static Action<T, object> GetValueSetter<T>(this PropertyInfo propertyInfo)
        {
            if (typeof(T) != propertyInfo.DeclaringType)
                throw new ArgumentException("Generic param T must agree with the declaring type of the property.", nameof(propertyInfo));

            return (Action<T, object>)buildSetter(propertyInfo, typeof(T));
        }

        private static Delegate buildSetter(this PropertyInfo propertyInfo, Type instanceType)
        {
            var instance = Expression.Parameter(instanceType, "i");    // set(object i, object a) =>
            var argument = Expression.Parameter(typeof(object), "a");

            Expression convertedInstance = instanceType == typeof(object) ?
                (Expression)Expression.Convert(instance, propertyInfo.DeclaringType) :    // var p = (declaringType)i
                (Expression)instance;

            var setterCall = Expression.Call(     // i.<propertyInfo> = (propertyType)a;
                    convertedInstance,
                    propertyInfo.SetMethod,
                    Expression.Convert(argument, propertyInfo.PropertyType));

            return Expression.Lambda(setterCall, instance, argument).Compile();
        }

        public static Action<object, object> GetValueSetter(this PropertyInfo propertyInfo)
        {
            return (Action<object, object>)buildSetter(propertyInfo, typeof(object));
        }
    }
}

#endif