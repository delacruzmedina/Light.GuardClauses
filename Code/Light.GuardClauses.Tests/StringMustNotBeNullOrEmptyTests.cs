﻿using System;
using FluentAssertions;
using Light.GuardClauses.Exceptions;
using Light.GuardClauses.Tests.CustomMessagesAndExceptions;
using Xunit;

namespace Light.GuardClauses.Tests
{
    [Trait("Category", Traits.FunctionalTests)]
    public sealed class StringMustNotBeNullOrEmptyTests : ICustomMessageAndExceptionTestDataProvider
    {
        [Fact(DisplayName = "MustNotBeNullOrEmpty must throw an ArgumentNullException when a string is null.")]
        public void StringNull()
        {
            string @string = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            Action act = () => @string.MustNotBeNullOrEmpty(nameof(@string));

            act.ShouldThrow<ArgumentNullException>()
               .And.ParamName.Should().Be(nameof(@string));
        }

        [Fact(DisplayName = "MustNotBeNullOrEmpty must throw an EmptyStringException when the parameter is empty.")]
        public void EmptyString()
        {
            var @string = string.Empty;

            Action act = () => @string.MustNotBeNullOrEmpty(nameof(@string));

            act.ShouldThrow<EmptyStringException>()
               .And.ParamName.Should().Be(nameof(@string));
        }

        [Theory(DisplayName = "MustNotBeNullOrEmpty must not throw an excpetion when a proper string reference is handled.")]
        [InlineData("abc")]
        [InlineData("Hello World")]
        public void ProperString(string @string)
        {
            Action act = () => @string.MustNotBeNullOrEmpty(nameof(@string));

            act.ShouldNotThrow();
        }

        public void PopulateTestDataForCustomExceptionAndCustomMessageTests(CustomMessageAndExceptionTestData testData)
        {
            testData.Add(new CustomExceptionTest(exception => string.Empty.MustNotBeNullOrEmpty(exception: exception)));
            testData.Add(new CustomExceptionTest(exception => ((string) null).MustNotBeNullOrEmpty(exception: exception)));

            testData.Add(new CustomMessageTest<EmptyStringException>(message => string.Empty.MustNotBeNullOrEmpty(message: message)));
            testData.Add(new CustomMessageTest<ArgumentNullException>(message => ((string) null).MustNotBeNullOrEmpty(message: message)));
        }
    }
}