﻿using System;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using Light.GuardClauses.Exceptions;

namespace Light.GuardClauses.Performance.CommonAssertions
{
    public class MustHaveValueIntBenchmarks : DefaultBenchmark
    {
        public readonly int? Nullable = 42;

        [Benchmark(Baseline = true)]
        public int? BaseVersion()
        {
            if (Nullable.HasValue == false) throw new NullableHasNoValueException(nameof(Nullable));
            return Nullable;
        }

        [Benchmark]
        public int? OldVersionWithParameterName() => Nullable.OldMustHaveValue(nameof(Nullable));

        [Benchmark]
        public int? LightGuardClausesWithParameterName() => Nullable.MustHaveValue(nameof(Nullable));

        [Benchmark]
        public int? NewVersionReturnFast() => Nullable.NewMustHaveValueReturnFast(nameof(Nullable));

        [Benchmark]
        public int? LightGuardClausesWithCustomException() => Nullable.MustHaveValue(() => new Exception());
    }

    public class MustHaveValueDoubleBenchmarks : DefaultBenchmark
    {
        public readonly double? Nullable = 42.74;

        [Benchmark(Baseline = true)]
        public double? BaseVersion()
        {
            if (Nullable.HasValue == false) throw new NullableHasNoValueException(nameof(Nullable));
            return Nullable;
        }

        [Benchmark]
        public double? OldVersionWithParameterName() => Nullable.OldMustHaveValue(nameof(Nullable));

        [Benchmark]
        public double? LightGuardClausesWithParameterName() => Nullable.MustHaveValue(nameof(Nullable));

        [Benchmark]
        public double? NewVersionReturnFast() => Nullable.NewMustHaveValueReturnFast(nameof(Nullable));

        [Benchmark]
        public double? LightGuardClausesWithCustomException() => Nullable.MustHaveValue(() => new Exception());
    }

    public static class MustHaveValueExtensionMethods
    {
        public static T? OldMustHaveValue<T>(this T? parameter, string parameterName = null, string message = null, Func<Exception> exception = null)
            where T : struct
        {
            if (parameter.HasValue)
                return parameter;

            throw exception?.Invoke() ?? (message != null ? new NullableHasNoValueException(message, parameterName) : new NullableHasNoValueException(parameterName));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T? NewMustHaveValueReturnFast<T>(this T? parameter, string parameterName = null, string message = null) where T : struct
        {
            if (parameter.HasValue) return parameter;
            Throw.NullableHasNoValue(parameterName, message);
            return null;
        }
    }
}