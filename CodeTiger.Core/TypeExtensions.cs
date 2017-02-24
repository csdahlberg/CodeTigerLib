﻿using System;
using System.Linq;
using System.Reflection;

namespace CodeTiger
{
    /// <summary>
    /// Contains extension methods for the <see cref="Type"/> class.
    /// </summary>
    public static class TypeExtensions
    {
        private const TypeAttributes StaticAttributes
            = TypeAttributes.Class | TypeAttributes.Abstract | TypeAttributes.Sealed;

        /// <summary>
        /// Determines whether a given type was generated by a compiler.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns><c>true</c> if the type was generated by a compiler, <c>false</c> otherwise.</returns>
        public static bool IsCompilerGenerated(this Type type)
        {
            Guard.ArgumentIsNotNull(nameof(type), type);

            return type.GetTypeInfo().IsCompilerGenerated();
        }

        /// <summary>
        /// Determines whether a given type is static.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns><c>true</c> if the type is static, <c>false</c> otherwise.</returns>
        public static bool IsStatic(this Type type)
        {
            Guard.ArgumentIsNotNull(nameof(type), type);

            return type.GetTypeInfo().IsStatic();
        }
    }
}