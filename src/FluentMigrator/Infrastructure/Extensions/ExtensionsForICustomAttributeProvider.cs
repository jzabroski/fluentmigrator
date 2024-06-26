#region License
//
// Copyright (c) 2007-2024, Fluent Migrator Project
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion

using System;
using System.Linq;
using System.Reflection;

namespace FluentMigrator.Infrastructure.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="ICustomAttributeProvider"/>
    /// </summary>
    public static class ExtensionsForICustomAttributeProvider
    {
        /// <summary>
        /// Get the first attribute of exactly the given type
        /// </summary>
        /// <typeparam name="T">The attribute type to search for</typeparam>
        /// <param name="member">The <see cref="ICustomAttributeProvider"/></param>
        /// <returns>The found attribute or <c>null</c></returns>
        public static T GetOneAttribute<T>(this ICustomAttributeProvider member)
            where T : Attribute
        {
            return member.GetOneAttribute<T>(false);
        }

        /// <summary>
        /// Get the first attribute of the given type
        /// </summary>
        /// <typeparam name="T">The attribute type to search for</typeparam>
        /// <param name="member">The <see cref="ICustomAttributeProvider"/></param>
        /// <param name="inherit"><c>true</c> when attributes derived form <typeparamref name="T"/> should be returned too</param>
        /// <returns>The found attribute or <c>null</c></returns>
        public static T GetOneAttribute<T>(this ICustomAttributeProvider member, bool inherit)
            where T : Attribute
        {
            return member.GetCustomAttributes(typeof(T), inherit).OfType<T>().FirstOrDefault();
        }

        /// <summary>
        /// Get all attributes of exactly the given type
        /// </summary>
        /// <typeparam name="T">The attribute type to search for</typeparam>
        /// <param name="member">The <see cref="ICustomAttributeProvider"/></param>
        /// <returns>The found attributes</returns>
        public static T[] GetAllAttributes<T>(this ICustomAttributeProvider member)
            where T : Attribute
        {
            return member.GetAllAttributes<T>(false);
        }

        /// <summary>
        /// Get all attributes of the given type
        /// </summary>
        /// <typeparam name="T">The attribute type to search for</typeparam>
        /// <param name="member">The <see cref="ICustomAttributeProvider"/></param>
        /// <param name="inherit"><c>true</c> when attributes derived form <typeparamref name="T"/> should be returned too</param>
        /// <returns>The found attributes</returns>
        public static T[] GetAllAttributes<T>(this ICustomAttributeProvider member, bool inherit)
            where T : Attribute
        {
            return member.GetCustomAttributes(typeof(T), inherit).OfType<T>().ToArray();
        }

        /// <summary>
        /// Returns a value indicating whether the custom attribute provider contains the given attribute
        /// </summary>
        /// <typeparam name="T">The attribute type to search for</typeparam>
        /// <param name="member">The <see cref="ICustomAttributeProvider"/></param>
        /// <returns><c>true</c> when an attribute with the given type could be found</returns>
        public static bool HasAttribute<T>(this ICustomAttributeProvider member)
            where T : Attribute
        {
            return member.HasAttribute<T>(false);
        }

        /// <summary>
        /// Returns a value indicating whether the custom attribute provider contains the given attribute
        /// </summary>
        /// <typeparam name="T">The attribute type to search for</typeparam>
        /// <param name="member">The <see cref="ICustomAttributeProvider"/></param>
        /// <param name="inherit"><c>true</c> when attributes derived form <typeparamref name="T"/> should be returned too</param>
        /// <returns><c>true</c> when an attribute with the given type could be found</returns>
        public static bool HasAttribute<T>(this ICustomAttributeProvider member, bool inherit)
            where T : Attribute
        {
            return member.IsDefined(typeof(T), inherit);
        }
    }
}
