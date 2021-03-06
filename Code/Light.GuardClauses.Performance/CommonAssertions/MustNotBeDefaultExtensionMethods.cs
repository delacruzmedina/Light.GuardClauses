﻿using System;
using System.Runtime.CompilerServices;
using Light.GuardClauses.Exceptions;

namespace Light.GuardClauses.Performance.CommonAssertions
{
    public static class MustNotBeDefaultExtensionMethods
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustNotBeDefaultV1<T>(this T parameter, string parameterName = null, string message = null)
        {
            if (default(T) == null)
            {
                if (parameter != null)
                    return parameter;

                ThrowMustNotBeNullException(parameterName, message);
                return default(T);
            }

            if (parameter.Equals(default(T)) == false)
                return parameter;

            ThrowParameterDefaultException(parameterName, message);
            return default(T);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustNotBeDefaultV2<T>(this T parameter, string parameterName = null, string message = null)
        {
            if (parameter == null)
                ThrowMustNotBeNullException(parameterName, message);

            // ReSharper disable once PossibleNullReferenceException
            if (parameter.Equals(default(T)))
                ThrowParameterDefaultException(parameterName, message);

            return parameter;
        }

        private static void ThrowParameterDefaultException(string parameterName, string message)
        {
            throw new ArgumentException(message ?? $"{parameterName ?? "The value"} must not be the default value.", parameterName);
        }

        private static void ThrowMustNotBeNullException(string parameterName, string message)
        {
            throw new ArgumentNullException(parameterName, message ?? $"{parameterName ?? "The value"} must not be null.");
        }

        public static T OldMustNotBeDefault<T>(this T parameter, string parameterName = null, string message = null, Func<Exception> exception = null)
        {
            if (parameter == null)
                throw exception?.Invoke() ?? new ArgumentNullException(parameterName, message ?? $"{parameterName ?? "The value"} must not be null.");

            if (parameter.Equals(default(T)))
                throw exception?.Invoke() ?? new ArgumentDefaultException(parameterName, message ?? $"{parameterName ?? "The value"} must not be the default value.");

            return parameter;
        }
    }
}