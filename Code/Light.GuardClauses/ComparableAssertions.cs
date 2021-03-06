﻿using System;
using System.Runtime.CompilerServices;
using Light.GuardClauses.Exceptions;

namespace Light.GuardClauses
{
    /// <summary>
    /// The <see cref="ComparableAssertions" /> class contains extension methods that check assertions for the <see cref="IComparable{T}" /> interface.
    /// </summary>
    public static class ComparableAssertions
    {
        /// <summary>
        /// Ensures that the specified <paramref name="parameter" /> is not less than the given <paramref name="boundary" /> value, or otherwise throws an <see cref="ArgumentOutOfRangeException" />.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="boundary">The boundary value that <paramref name="parameter" /> must be equal or greater to.</param>
        /// <param name="parameterName">The name of the parameter (optional).</param>
        /// <param name="message">The message that should be injected into the <see cref="ArgumentOutOfRangeException" /> (optional).</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the specified <paramref name="parameter" /> is less than <paramref name="boundary" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustNotBeLessThan<T>(this T parameter, T boundary, string parameterName = null, string message = null) where T : IComparable<T>
        {
            if (parameter.CompareTo(boundary) < 0)
                Throw.MustNotBeLessThan(parameter, boundary, parameterName, message);
            return parameter;
        }

        /// <summary>
        /// Ensures that the specified <paramref name="parameter" /> is not less than the given <paramref name="boundary" /> value, or otherwise throws your custom exception.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="boundary">The boundary value that <paramref name="parameter" /> must be equal or greater to.</param>
        /// <param name="exceptionFactory">The delegate that creates the exception to be thrown.</param>
        /// <exception cref="Exception">Your custom exception thrown when <paramref name="parameter" /> cannot be downcasted to the specified value.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustNotBeLessThan<T>(this T parameter, T boundary, Func<Exception> exceptionFactory) where T : IComparable<T>
        {
            if (parameter.CompareTo(boundary) < 0)
                Throw.CustomException(exceptionFactory);
            return parameter;
        }

        /// <summary>
        /// Ensures that the specified <paramref name="parameter" /> is not less than the given <paramref name="boundary" /> value, or otherwise throws your custom exception.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="boundary">The boundary value that <paramref name="parameter" /> must be equal or greater to.</param>
        /// <param name="exceptionFactory">The delegate that creates the exception to be thrown.</param>
        /// <exception cref="Exception">Your custom exception thrown when <paramref name="parameter" /> cannot be downcasted to the specified value.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustNotBeLessThan<T>(this T parameter, T boundary, Func<T, Exception> exceptionFactory) where T : IComparable<T>
        {
            if (parameter.CompareTo(boundary) < 0)
                Throw.CustomException(exceptionFactory, parameter);
            return parameter;
        }

        /// <summary>
        /// Ensures that the specified <paramref name="parameter" /> is not less than the given <paramref name="boundary" /> value, or otherwise throws your custom exception.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="boundary">The boundary value that <paramref name="parameter" /> must be equal or greater to.</param>
        /// <param name="exceptionFactory">The delegate that creates the exception to be thrown.</param>
        /// <exception cref="Exception">Your custom exception thrown when <paramref name="parameter" /> cannot be downcasted to the specified value.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustNotBeLessThan<T>(this T parameter, T boundary, Func<T, T, Exception> exceptionFactory) where T : IComparable<T>
        {
            if (parameter.CompareTo(boundary) < 0)
                Throw.CustomException(exceptionFactory, parameter, boundary);
            return parameter;
        }

        /// <summary>
        /// Ensures that the specified <paramref name="parameter" /> is less than the given <paramref name="boundary" /> value, or otherwise throws an <see cref="ArgumentOutOfRangeException" />.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="boundary">The boundary value that <paramref name="parameter" /> must be less than.</param>
        /// <param name="parameterName">The name of the parameter (optional).</param>
        /// <param name="message">The message that should be injected into the <see cref="ArgumentOutOfRangeException" /> (optional).</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the specified <paramref name="parameter" /> is greater than or equal to <paramref name="boundary" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustBeLessThan<T>(this T parameter, T boundary, string parameterName = null, string message = null) where T : IComparable<T>
        {
            if (parameter.CompareTo(boundary) >= 0)
                Throw.MustBeLessThan(parameter, boundary, parameterName, message);
            return parameter;
        }

        /// <summary>
        /// Ensures that the specified <paramref name="parameter" /> is less than the given <paramref name="boundary" /> value, or otherwise throws your custom exception.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="boundary">The boundary value that <paramref name="parameter" /> must be less than.</param>
        /// <param name="exceptionFactory">The delegate that creates the exception to be thrown.</param>
        /// <exception cref="Exception">Your custom exception thrown when the specified <paramref name="parameter" /> is greater than or equal to <paramref name="boundary" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustBeLessThan<T>(this T parameter, T boundary, Func<Exception> exceptionFactory) where T : IComparable<T>
        {
            if (parameter.CompareTo(boundary) >= 0)
                Throw.CustomException(exceptionFactory);
            return parameter;
        }

        /// <summary>
        /// Ensures that the specified <paramref name="parameter" /> is less than the given <paramref name="boundary" /> value, or otherwise throws your custom exception.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="boundary">The boundary value that <paramref name="parameter" /> must be less than.</param>
        /// <param name="exceptionFactory">The delegate that creates the exception to be thrown.</param>
        /// <exception cref="Exception">Your custom exception thrown when the specified <paramref name="parameter" /> is greater than or equal to <paramref name="boundary" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustBeLessThan<T>(this T parameter, T boundary, Func<T, Exception> exceptionFactory) where T : IComparable<T>
        {
            if (parameter.CompareTo(boundary) >= 0)
                Throw.CustomException(exceptionFactory, parameter);
            return parameter;
        }

        /// <summary>
        /// Ensures that the specified <paramref name="parameter" /> is less than the given <paramref name="boundary" /> value, or otherwise throws your custom exception.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="boundary">The boundary value that <paramref name="parameter" /> must be less than.</param>
        /// <param name="exceptionFactory">The delegate that creates the exception to be thrown.</param>
        /// <exception cref="Exception">Your custom exception thrown when the specified <paramref name="parameter" /> is greater than or equal to <paramref name="boundary" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustBeLessThan<T>(this T parameter, T boundary, Func<T, T, Exception> exceptionFactory) where T : IComparable<T>
        {
            if (parameter.CompareTo(boundary) >= 0)
                Throw.CustomException(exceptionFactory, parameter, boundary);
            return parameter;
        }

        /// <summary>
        /// Ensures that the specified <paramref name="parameter" /> is not less than or equal to the given <paramref name="boundary" /> value, or otherwise throws an <see cref="ArgumentOutOfRangeException" />.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="boundary">The boundary value that <paramref name="parameter" /> must be greater than.</param>
        /// <param name="parameterName">The name of the parameter (optional).</param>
        /// <param name="message">The message that should be injected into the <see cref="ArgumentOutOfRangeException" /> (optional).</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the specified <paramref name="parameter" /> is less than or equal to <paramref name="boundary" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustNotBeLessThanOrEqualTo<T>(this T parameter, T boundary, string parameterName = null, string message = null) where T : IComparable<T>
        {
            if (parameter.CompareTo(boundary) <= 0)
                Throw.MustNotBeLessThanOrEqualTo(parameter, boundary, parameterName, message);
            return parameter;
        }

        /// <summary>
        /// Ensures that the specified <paramref name="parameter" /> is not less than or equal to the given <paramref name="boundary" /> value, or otherwise throws your custom exception.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="boundary">The boundary value that <paramref name="parameter" /> must be greater than.</param>
        /// <param name="exceptionFactory">The delegate that creates the exception to be thrown.</param>
        /// <exception cref="Exception">Your custom exception thrown when the specified <paramref name="parameter" /> is less than or equal to <paramref name="boundary" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustNotBeLessThanOrEqualTo<T>(this T parameter, T boundary, Func<Exception> exceptionFactory) where T : IComparable<T>
        {
            if (parameter.CompareTo(boundary) <= 0)
                Throw.CustomException(exceptionFactory);
            return parameter;
        }

        /// <summary>
        /// Ensures that the specified <paramref name="parameter" /> is not less than or equal to the given <paramref name="boundary" /> value, or otherwise throws your custom exception.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="boundary">The boundary value that <paramref name="parameter" /> must be greater than.</param>
        /// <param name="exceptionFactory">The delegate that creates the exception to be thrown.</param>
        /// <exception cref="Exception">Your custom exception thrown when the specified <paramref name="parameter" /> is less than or equal to <paramref name="boundary" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustNotBeLessThanOrEqualTo<T>(this T parameter, T boundary, Func<T, Exception> exceptionFactory) where T : IComparable<T>
        {
            if (parameter.CompareTo(boundary) <= 0)
                Throw.CustomException(exceptionFactory, parameter);
            return parameter;
        }

        /// <summary>
        /// Ensures that the specified <paramref name="parameter" /> is not less than or equal to the given <paramref name="boundary" /> value, or otherwise throws your custom exception.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="boundary">The boundary value that <paramref name="parameter" /> must be greater than.</param>
        /// <param name="exceptionFactory">The delegate that creates the exception to be thrown.</param>
        /// <exception cref="Exception">Your custom exception thrown when the specified <paramref name="parameter" /> is less than or equal to <paramref name="boundary" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustNotBeLessThanOrEqualTo<T>(this T parameter, T boundary, Func<T, T, Exception> exceptionFactory) where T : IComparable<T>
        {
            if (parameter.CompareTo(boundary) <= 0)
                Throw.CustomException(exceptionFactory, parameter, boundary);
            return parameter;
        }

        /// <summary>
        /// Ensures that the specified <paramref name="parameter" /> is less than or equal to the given <paramref name="boundary" /> value, or otherwise throws an <see cref="ArgumentOutOfRangeException" />.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="boundary">The boundary value that <paramref name="parameter" /> must be less than or equal to.</param>
        /// <param name="parameterName">The name of the parameter (optional).</param>
        /// <param name="message">The message that should be injected into the <see cref="ArgumentOutOfRangeException" /> (optional).</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="parameter" /> is greater than <paramref name="boundary" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustBeLessThanOrEqualTo<T>(this T parameter, T boundary, string parameterName = null, string message = null) where T : IComparable<T>
        {
            if (parameter.CompareTo(boundary) > 0)
                Throw.MustBeLessThanOrEqualTo(parameter, boundary, parameterName, message);
            return parameter;
        }

        /// <summary>
        /// Ensures that the specified <paramref name="parameter" /> is less than or equal to the given <paramref name="boundary" /> value, or otherwise throws your custom exception.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="boundary">The boundary value that <paramref name="parameter" /> must be less than or equal to.</param>
        /// <param name="exceptionFactory">The delegate that creates the exception to be thrown.</param>
        /// <exception cref="Exception">Your custom exception thrown when <paramref name="parameter" /> is greater than <paramref name="boundary" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustBeLessThanOrEqualTo<T>(this T parameter, T boundary, Func<Exception> exceptionFactory) where T : IComparable<T>
        {
            if (parameter.CompareTo(boundary) > 0)
                Throw.CustomException(exceptionFactory);
            return parameter;
        }

        /// <summary>
        /// Ensures that the specified <paramref name="parameter" /> is less than or equal to the given <paramref name="boundary" /> value, or otherwise throws your custom exception.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="boundary">The boundary value that <paramref name="parameter" /> must be less than or equal to.</param>
        /// <param name="exceptionFactory">The delegate that creates the exception to be thrown.</param>
        /// <exception cref="Exception">Your custom exception thrown when <paramref name="parameter" /> is greater than <paramref name="boundary" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustBeLessThanOrEqualTo<T>(this T parameter, T boundary, Func<T, Exception> exceptionFactory) where T : IComparable<T>
        {
            if (parameter.CompareTo(boundary) > 0)
                Throw.CustomException(exceptionFactory, parameter);
            return parameter;
        }

        /// <summary>
        /// Ensures that the specified <paramref name="parameter" /> is less than or equal to the given <paramref name="boundary" /> value, or otherwise throws your custom exception.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="boundary">The boundary value that <paramref name="parameter" /> must be less than or equal to.</param>
        /// <param name="exceptionFactory">The delegate that creates the exception to be thrown.</param>
        /// <exception cref="Exception">Your custom exception thrown when <paramref name="parameter" /> is greater than <paramref name="boundary" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustBeLessThanOrEqualTo<T>(this T parameter, T boundary, Func<T, T, Exception> exceptionFactory) where T : IComparable<T>
        {
            if (parameter.CompareTo(boundary) > 0)
                Throw.CustomException(exceptionFactory, parameter, boundary);
            return parameter;
        }

        /// <summary>
        /// Ensures that the specified <paramref name="parameter" /> is not greater than the given <paramref name="boundary" /> value, or otherwise throws an <see cref="ArgumentOutOfRangeException" />.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="boundary">The boundary value that <paramref name="parameter" /> must be less than or equal to.</param>
        /// <param name="parameterName">The name of the parameter (optional).</param>
        /// <param name="message">The message that should be injected into the <see cref="ArgumentOutOfRangeException" /> (optional).</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="parameter" /> is greater than <paramref name="boundary" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustNotBeGreaterThan<T>(this T parameter, T boundary, string parameterName = null, string message = null) where T : IComparable<T>
        {
            if (parameter.CompareTo(boundary) > 0)
                Throw.MustNotBeGreaterThan(parameter, boundary, parameterName, message);
            return parameter;
        }

        /// <summary>
        /// Ensures that the specified <paramref name="parameter" /> is not greater than the given <paramref name="boundary" /> value, or otherwise throws your custom exception.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="boundary">The boundary value that <paramref name="parameter" /> must be less than or equal to.</param>
        /// <param name="exceptionFactory">The delegate that creates the exception to be thrown.</param>
        /// <exception cref="Exception">Your custom exception thrown when <paramref name="parameter" /> is greater than <paramref name="boundary" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustNotBeGreaterThan<T>(this T parameter, T boundary, Func<Exception> exceptionFactory) where T : IComparable<T>
        {
            if (parameter.CompareTo(boundary) > 0)
                Throw.CustomException(exceptionFactory);
            return parameter;
        }

        /// <summary>
        /// Ensures that the specified <paramref name="parameter" /> is not greater than the given <paramref name="boundary" /> value, or otherwise throws your custom exception.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="boundary">The boundary value that <paramref name="parameter" /> must be less than or equal to.</param>
        /// <param name="exceptionFactory">The delegate that creates the exception to be thrown.</param>
        /// <exception cref="Exception">Your custom exception thrown when <paramref name="parameter" /> is greater than <paramref name="boundary" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustNotBeGreaterThan<T>(this T parameter, T boundary, Func<T, Exception> exceptionFactory) where T : IComparable<T>
        {
            if (parameter.CompareTo(boundary) > 0)
                Throw.CustomException(exceptionFactory, parameter);
            return parameter;
        }

        /// <summary>
        /// Ensures that the specified <paramref name="parameter" /> is not greater than the given <paramref name="boundary" /> value, or otherwise throws your custom exception.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="boundary">The boundary value that <paramref name="parameter" /> must be less than or equal to.</param>
        /// <param name="exceptionFactory">The delegate that creates the exception to be thrown.</param>
        /// <exception cref="Exception">Your custom exception thrown when <paramref name="parameter" /> is greater than <paramref name="boundary" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustNotBeGreaterThan<T>(this T parameter, T boundary, Func<T, T, Exception> exceptionFactory) where T : IComparable<T>
        {
            if (parameter.CompareTo(boundary) > 0)
                Throw.CustomException(exceptionFactory, parameter, boundary);
            return parameter;
        }

        /// <summary>
        /// Ensures that the specified <paramref name="parameter" /> is greater than the given <paramref name="boundary" /> value, or otherwise throws an <see cref="ArgumentOutOfRangeException" />.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="boundary">The boundary value that <paramref name="parameter" /> must be greater than.</param>
        /// <param name="parameterName">The name of the parameter (optional).</param>
        /// <param name="message">The message that should be injected into the <see cref="ArgumentOutOfRangeException" /> (optional).</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="parameter" /> is less than or equal to <paramref name="boundary" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustBeGreaterThan<T>(this T parameter, T boundary, string parameterName = null, string message = null) where T : IComparable<T>
        {
            if (parameter.CompareTo(boundary) <= 0)
                Throw.MustBeGreaterThan(parameter, boundary, parameterName, message);
            return parameter;
        }

        /// <summary>
        /// Ensures that the specified <paramref name="parameter" /> is greater than the given <paramref name="boundary" /> value, or otherwise throws your custom exception.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="boundary">The boundary value that <paramref name="parameter" /> must be greater than.</param>
        /// <param name="exceptionFactory">The delegate that creates the exception to be thrown.</param>
        /// <exception cref="Exception">Your custom exception thrown when <paramref name="parameter" /> is less than or equal to <paramref name="boundary" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustBeGreaterThan<T>(this T parameter, T boundary, Func<Exception> exceptionFactory) where T : IComparable<T>
        {
            if (parameter.CompareTo(boundary) <= 0)
                Throw.CustomException(exceptionFactory);
            return parameter;
        }

        /// <summary>
        /// Ensures that the specified <paramref name="parameter" /> is greater than the given <paramref name="boundary" /> value, or otherwise throws your custom exception.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="boundary">The boundary value that <paramref name="parameter" /> must be greater than.</param>
        /// <param name="exceptionFactory">The delegate that creates the exception to be thrown.</param>
        /// <exception cref="Exception">Your custom exception thrown when <paramref name="parameter" /> is less than or equal to <paramref name="boundary" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustBeGreaterThan<T>(this T parameter, T boundary, Func<T, Exception> exceptionFactory) where T : IComparable<T>
        {
            if (parameter.CompareTo(boundary) <= 0)
                Throw.CustomException(exceptionFactory, parameter);
            return parameter;
        }

        /// <summary>
        /// Ensures that the specified <paramref name="parameter" /> is greater than the given <paramref name="boundary" /> value, or otherwise throws your custom exception.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="boundary">The boundary value that <paramref name="parameter" /> must be greater than.</param>
        /// <param name="exceptionFactory">The delegate that creates the exception to be thrown.</param>
        /// <exception cref="Exception">Your custom exception thrown when <paramref name="parameter" /> is less than or equal to <paramref name="boundary" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustBeGreaterThan<T>(this T parameter, T boundary, Func<T, T, Exception> exceptionFactory) where T : IComparable<T>
        {
            if (parameter.CompareTo(boundary) <= 0)
                Throw.CustomException(exceptionFactory, parameter, boundary);
            return parameter;
        }

        /// <summary>
        /// Ensures that the specified <paramref name="parameter" /> is not greater than or equal to the given <paramref name="boundary" /> value, or otherwise throws an <see cref="ArgumentOutOfRangeException" />.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="boundary">The boundary value that <paramref name="parameter" /> must be less than.</param>
        /// <param name="parameterName">The name of the parameter (optional).</param>
        /// <param name="message">The message that should be injected into the <see cref="ArgumentOutOfRangeException" /> (optional).</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="parameter" /> is greater than or equal to <paramref name="boundary" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustNotBeGreaterThanOrEqualTo<T>(this T parameter, T boundary, string parameterName = null, string message = null) where T : IComparable<T>
        {
            if (parameter.CompareTo(boundary) >= 0)
                Throw.MustNotBeGreaterThanOrEqualTo(parameter, boundary, parameterName, message);
            return parameter;
        }

        /// <summary>
        /// Ensures that the specified <paramref name="parameter" /> is not greater than or equal to the given <paramref name="boundary" /> value, or otherwise throws your custom exception.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="boundary">The boundary value that <paramref name="parameter" /> must be less than.</param>
        /// <param name="exceptionFactory">The delegate that creates the exception to be thrown.</param>
        /// <exception cref="Exception">Your custom exception thrown when <paramref name="parameter" /> is greater than or equal to <paramref name="boundary" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustNotBeGreaterThanOrEqualTo<T>(this T parameter, T boundary, Func<Exception> exceptionFactory) where T : IComparable<T>
        {
            if (parameter.CompareTo(boundary) >= 0)
                Throw.CustomException(exceptionFactory);
            return parameter;
        }

        /// <summary>
        /// Ensures that the specified <paramref name="parameter" /> is not greater than or equal to the given <paramref name="boundary" /> value, or otherwise throws your custom exception.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="boundary">The boundary value that <paramref name="parameter" /> must be less than.</param>
        /// <param name="exceptionFactory">The delegate that creates the exception to be thrown.</param>
        /// <exception cref="Exception">Your custom exception thrown when <paramref name="parameter" /> is greater than or equal to <paramref name="boundary" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustNotBeGreaterThanOrEqualTo<T>(this T parameter, T boundary, Func<T, Exception> exceptionFactory) where T : IComparable<T>
        {
            if (parameter.CompareTo(boundary) >= 0)
                Throw.CustomException(exceptionFactory, parameter);
            return parameter;
        }

        /// <summary>
        /// Ensures that the specified <paramref name="parameter" /> is not greater than or equal to the given <paramref name="boundary" /> value, or otherwise throws your custom exception.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="boundary">The boundary value that <paramref name="parameter" /> must be less than.</param>
        /// <param name="exceptionFactory">The delegate that creates the exception to be thrown.</param>
        /// <exception cref="Exception">Your custom exception thrown when <paramref name="parameter" /> is greater than or equal to <paramref name="boundary" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustNotBeGreaterThanOrEqualTo<T>(this T parameter, T boundary, Func<T, T, Exception> exceptionFactory) where T : IComparable<T>
        {
            if (parameter.CompareTo(boundary) >= 0)
                Throw.CustomException(exceptionFactory, parameter, boundary);
            return parameter;
        }

        /// <summary>
        /// Ensures that the specified <paramref name="parameter" /> is greater than or equal to the given <paramref name="boundary" /> value, or otherwise throws an <see cref="ArgumentOutOfRangeException" />.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="boundary">The boundary value that <paramref name="parameter" /> must be greater than or equal to.</param>
        /// <param name="parameterName">The name of the parameter (optional).</param>
        /// <param name="message">The message that should be injected into the <see cref="ArgumentOutOfRangeException" /> (optional).</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="parameter" /> is less than <paramref name="boundary" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustBeGreaterThanOrEqualTo<T>(this T parameter, T boundary, string parameterName = null, string message = null) where T : IComparable<T>
        {
            if (parameter.CompareTo(boundary) < 0)
                Throw.MustBeGreaterThanOrEqualTo(parameter, boundary, parameterName, message);
            return parameter;
        }

        /// <summary>
        /// Ensures that the specified <paramref name="parameter" /> is greater than or equal to the given <paramref name="boundary" /> value, or otherwise throws your custom exception.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="boundary">The boundary value that <paramref name="parameter" /> must be greater than or equal to.</param>
        /// <param name="exceptionFactory">The delegate that creates the exception to be thrown.</param>
        /// <exception cref="Exception">Your custom exception thrown when <paramref name="parameter" /> is less than <paramref name="boundary" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustBeGreaterThanOrEqualTo<T>(this T parameter, T boundary, Func<Exception> exceptionFactory) where T : IComparable<T>
        {
            if (parameter.CompareTo(boundary) < 0)
                Throw.CustomException(exceptionFactory);
            return parameter;
        }

        /// <summary>
        /// Ensures that the specified <paramref name="parameter" /> is greater than or equal to the given <paramref name="boundary" /> value, or otherwise throws your custom exception.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="boundary">The boundary value that <paramref name="parameter" /> must be greater than or equal to.</param>
        /// <param name="exceptionFactory">The delegate that creates the exception to be thrown.</param>
        /// <exception cref="Exception">Your custom exception thrown when <paramref name="parameter" /> is less than <paramref name="boundary" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustBeGreaterThanOrEqualTo<T>(this T parameter, T boundary, Func<T, Exception> exceptionFactory) where T : IComparable<T>
        {
            if (parameter.CompareTo(boundary) < 0)
                Throw.CustomException(exceptionFactory, parameter);
            return parameter;
        }

        /// <summary>
        /// Ensures that the specified <paramref name="parameter" /> is greater than or equal to the given <paramref name="boundary" /> value, or otherwise throws your custom exception.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="boundary">The boundary value that <paramref name="parameter" /> must be greater than or equal to.</param>
        /// <param name="exceptionFactory">The delegate that creates the exception to be thrown.</param>
        /// <exception cref="Exception">Your custom exception thrown when <paramref name="parameter" /> is less than <paramref name="boundary" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustBeGreaterThanOrEqualTo<T>(this T parameter, T boundary, Func<T, T, Exception> exceptionFactory) where T : IComparable<T>
        {
            if (parameter.CompareTo(boundary) < 0)
                Throw.CustomException(exceptionFactory, parameter, boundary);
            return parameter;
        }

        /// <summary>
        /// Ensures that <paramref name="parameter" /> is within the specified <paramref name="range" />, or otherwise throws an <see cref="ArgumentOutOfRangeException" />.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="range">The range that <paramref name="parameter" /> must be in between.</param>
        /// <param name="parameterName">The name of the parameter (optional).</param>
        /// <param name="message">The message that should be injected into the <see cref="ArgumentOutOfRangeException" /> (optional).</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="parameter" /> is not within the specified <paramref name="range" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustBeIn<T>(this T parameter, Range<T> range, string parameterName = null, string message = null) where T : IComparable<T>
        {
            if (range.IsValueWithinRange(parameter) == false)
                Throw.MustBeInRange(parameter, range, parameterName, message);
            return parameter;
        }

        /// <summary>
        /// Ensures that <paramref name="parameter" /> is within the specified <paramref name="range" />, or otherwise throws your custom exception.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="range">The range that <paramref name="parameter" /> must be in between.</param>
        /// <param name="exceptionFactory">The delegate that creates the exception to be thrown.</param>
        /// <exception cref="Exception">Your custom exception thrown when <paramref name="parameter" /> is not within the specified <paramref name="range" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustBeIn<T>(this T parameter, Range<T> range, Func<Exception> exceptionFactory) where T : IComparable<T>
        {
            if (range.IsValueWithinRange(parameter) == false)
                Throw.CustomException(exceptionFactory);
            return parameter;
        }

        /// <summary>
        /// Ensures that <paramref name="parameter" /> is within the specified <paramref name="range" />, or otherwise throws your custom exception.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="range">The range that <paramref name="parameter" /> must be in between.</param>
        /// <param name="exceptionFactory">The delegate that creates the exception to be thrown.</param>
        /// <exception cref="Exception">Your custom exception thrown when <paramref name="parameter" /> is not within the specified <paramref name="range" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustBeIn<T>(this T parameter, Range<T> range, Func<T, Exception> exceptionFactory) where T : IComparable<T>
        {
            if (range.IsValueWithinRange(parameter) == false)
                Throw.CustomException(exceptionFactory, parameter);
            return parameter;
        }

        /// <summary>
        /// Ensures that <paramref name="parameter" /> is within the specified <paramref name="range" />, or otherwise throws your custom exception.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="range">The range that <paramref name="parameter" /> must be in between.</param>
        /// <param name="exceptionFactory">The delegate that creates the exception to be thrown.</param>
        /// <exception cref="Exception">Your custom exception thrown when <paramref name="parameter" /> is not within the specified <paramref name="range" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustBeIn<T>(this T parameter, Range<T> range, Func<T, Range<T>, Exception> exceptionFactory) where T : IComparable<T>
        {
            if (range.IsValueWithinRange(parameter) == false)
                Throw.CustomException(exceptionFactory, parameter, range);
            return parameter;
        }

        /// <summary>
        /// Checks if the parameter value is within the specified range.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="range">The range that <paramref name="parameter" /> must be in between.</param>
        /// <returns>True if the parameter is within the specified range, else false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsIn<T>(this T parameter, Range<T> range) where T : IComparable<T>
        {
            return range.IsValueWithinRange(parameter);
        }

        /// <summary>
        /// Ensures that <paramref name="parameter" /> is not within the specified range, or otherwise throws an <see cref="ArgumentOutOfRangeException" />.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="range">The range that <paramref name="parameter" /> must not be in between.</param>
        /// <param name="parameterName">The name of the parameter (optional).</param>
        /// <param name="message">The message that should be injected into the <see cref="ArgumentOutOfRangeException" /> (optional).</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="parameter" /> is within <paramref name="range" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustNotBeIn<T>(this T parameter, Range<T> range, string parameterName = null, string message = null) where T : IComparable<T>
        {
            if (range.IsValueWithinRange(parameter))
                Throw.MustNotBeInRange(parameter, range, parameterName, message);
            return parameter;
        }

        /// <summary>
        /// Ensures that <paramref name="parameter" /> is not within the specified range, or otherwise throws your custom exception.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="range">The range that <paramref name="parameter" /> must not be in between.</param>
        /// <param name="exceptionFactory">The delegate that creates the exception to be thrown.</param>
        /// <exception cref="Exception">Your custom exception thrown when <paramref name="parameter" /> is within <paramref name="range" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustNotBeIn<T>(this T parameter, Range<T> range, Func<Exception> exceptionFactory) where T : IComparable<T>
        {
            if (range.IsValueWithinRange(parameter))
                Throw.CustomException(exceptionFactory);
            return parameter;
        }

        /// <summary>
        /// Ensures that <paramref name="parameter" /> is not within the specified range, or otherwise throws your custom exception.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="range">The range that <paramref name="parameter" /> must not be in between.</param>
        /// <param name="exceptionFactory">The delegate that creates the exception to be thrown.</param>
        /// <exception cref="Exception">Your custom exception thrown when <paramref name="parameter" /> is within <paramref name="range" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustNotBeIn<T>(this T parameter, Range<T> range, Func<T, Exception> exceptionFactory) where T : IComparable<T>
        {
            if (range.IsValueWithinRange(parameter))
                Throw.CustomException(exceptionFactory, parameter);
            return parameter;
        }

        /// <summary>
        /// Ensures that <paramref name="parameter" /> is not within the specified range, or otherwise throws your custom exception.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="range">The range that <paramref name="parameter" /> must not be in between.</param>
        /// <param name="exceptionFactory">The delegate that creates the exception to be thrown.</param>
        /// <exception cref="Exception">Your custom exception thrown when <paramref name="parameter" /> is within <paramref name="range" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MustNotBeIn<T>(this T parameter, Range<T> range, Func<T, Range<T>, Exception> exceptionFactory) where T : IComparable<T>
        {
            if (range.IsValueWithinRange(parameter))
                Throw.CustomException(exceptionFactory, parameter, range);
            return parameter;
        }

        /// <summary>
        /// Checks if the parameter is not within the specified range.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="range">The range that <paramref name="parameter" /> must not be in between.</param>
        /// <returns>True if the parameter value is not in between of the specified range, else false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNotIn<T>(this T parameter, Range<T> range) where T : IComparable<T>
        {
            return !range.IsValueWithinRange(parameter);
        }
    }
}