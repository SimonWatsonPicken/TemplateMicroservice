﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace TemplateMicroservice.Domain
{
    public static class Required
    {
        /// <summary>
        /// Asserts that the given string is not null, empty or whitespace.</summary>
        /// <param name="value">The string to check.</param>
        /// <param name="name">The name of the string parameter.</param>
        /// <param name="message">The custom message to display in case of an exception.</param>
        /// <exception cref="ArgumentNullException">Thrown if the string is null, empty or whitespace.</exception>
        public static void StringNotEmpty(string value, string name = null, string message = null)
        {
            if (!string.IsNullOrWhiteSpace(value)) return;

            var paramName = string.IsNullOrWhiteSpace(name) ? "(no parameter name)" : name;

            throw value == null
                ? new ArgumentNullException(paramName, message ?? $"Parameter '{paramName}' must not be null.")
                : new ArgumentException(paramName, message ?? $"Parameter '{paramName}' must not be empty or whitespace.");
        }

        /// <summary>
        /// Asserts that the given guid is not empty.</summary>
        /// <param name="value">The guid to check.</param>
        /// <param name="name">The name of the guid parameter.</param>
        /// <param name="message">The custom message to display in case of an exception.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the guid is empty.</exception>
        public static void GuidNotEmpty(Guid value, string name = null, string message = null)
        {
            if (value != Guid.Empty) return;

            var paramName = string.IsNullOrWhiteSpace(name) ? "(no parameter name)" : name;

            throw new ArgumentOutOfRangeException(paramName, message ?? $"Parameter '{paramName}' must not be empty.");
        }

        /// <summary>
        /// Asserts that a list is not empty.
        /// </summary>
        /// <typeparam name="T">The type of the list.</typeparam>
        /// <param name="value">The list to check.</param>
        /// <param name="name">The argument name.</param>
        /// <param name="message">The custom message to display in case of an exception.</param>
        /// <exception cref="ArgumentException">Thrown if the list is empty.</exception>
        public static void CollectionNotEmpty<T>(IEnumerable<T> value, string name = null, string message = null)
        {
            ObjectNotNull(value, name, message);
            if (value.Any()) return;

            var paramName = string.IsNullOrWhiteSpace(name) ? "(no parameter name)" : name;

            throw new ArgumentException(paramName, message ?? $"List '{paramName}' must not be empty.");
        }

        /// <summary>
        /// Asserts that the given object is not null.</summary>
        /// <param name="value">The object to check.</param>
        /// <param name="name">The name of the object parameter.</param>
        /// <param name="message">The custom message to display in case of an exception.</param>
        /// <exception cref="ArgumentNullException">Thrown if the object is null.</exception>
        public static void ObjectNotNull(object value, string name = null, string message = null)
        {
            if (value != null) return;

            var paramName = string.IsNullOrWhiteSpace(name) ? "(no parameter name)" : name;

            throw new ArgumentNullException(paramName, message ?? $"Parameter '{paramName}' must not be null.");
        }

        /// <summary>
        /// Asserts whether an enumeration value is defined.
        /// </summary>
        /// <param name="enumType">The enumeration type.</param>
        /// <param name="value">The enumeration value.</param>
        /// <param name="name">The argument name.</param>
        /// <param name="message">The custom message to display in case of an exception.</param>
        /// <exception cref="ArgumentException">Thrown if the enumeration value is not defined.</exception>
        public static void EnumValueIsDefined(Type enumType, object value, string name = null, string message = null)
        {
            if (Enum.IsDefined(enumType, value) || (name == null)) return;

            var paramName = string.IsNullOrWhiteSpace(name) ? "(no parameter name)" : name;

            throw new ArgumentException(message ?? $"Parameter {paramName} has an invalid enum type {enumType}", paramName);
        }
        public static void EmailValid(string value, string name = null, string message = null)
        {
            StringNotEmpty(value, name, message);

            var paramName = string.IsNullOrWhiteSpace(name) ? "(no parameter name)" : name;

            try
            {
                // ReSharper disable once UnusedVariable
                var mailAddress = new MailAddress(value);
            }
            catch (FormatException)
            {
                throw new ArgumentException(message ?? $"Parameter {paramName} has an invalid email address.", paramName);
            }
        }
    }
}