﻿using System;
using FluentAssertions;
using Light.GuardClauses.Exceptions;
using Light.GuardClauses.Tests.CustomMessagesAndExceptions;
using Xunit;

namespace Light.GuardClauses.Tests.CommonAssertionsTests
{
    public sealed class MustHaveValueTests : ICustomMessageAndExceptionTestDataProvider
    {
        [Fact(DisplayName = "MustHaveValue must throw an exception when the specified Nullable<T> has no value.")]
        public void HasNoValue()
        {
            DateTime? value = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            Action act = () => value.MustHaveValue(nameof(value));

            act.Should().Throw<NullableHasNoValueException>()
               .And.ParamName.Should().Be(nameof(value));
        }

        [Theory(DisplayName = "MustHaveValue must not throw an exception when the specified Nullable<T> has a value.")]
        [InlineData(42)]
        [InlineData(20)]
        [InlineData(-187)]
        public void HasValue(int? value)
        {
            var result = value.MustHaveValue(nameof(value));

            result.Should().Be(value);
        }

        void ICustomMessageAndExceptionTestDataProvider.PopulateTestDataForCustomExceptionAndCustomMessageTests(CustomMessageAndExceptionTestData testData)
        {
            testData.AddExceptionTest(exception => ((double?) null).MustHaveValue(exception))
                    .AddMessageTest<NullableHasNoValueException>(message => ((int?) null).MustHaveValue(message: message));
        }
    }
}