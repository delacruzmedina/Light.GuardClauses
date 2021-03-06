﻿using System;
using FluentAssertions;
using Light.GuardClauses.Exceptions;
using Light.GuardClauses.Tests.CustomMessagesAndExceptions;
using Xunit;

namespace Light.GuardClauses.Tests.StringAssertionsTests
{
    public sealed class MustBeSubstringOfTests : ICustomMessageAndExceptionTestDataProvider
    {
        [Theory(DisplayName = "MustBeSubstringOf must throw a StringException when the specified string is not part of text.")]
        [InlineData("123", "abc")]
        [InlineData("ABC", "AB")]
        [InlineData("Hey, you over there!", "Where is the pigeon pie?")]
        public void IsNotSubstring(string invalidString, string text)
        {
            Action act = () => invalidString.MustBeSubstringOf(text, parameterName: nameof(invalidString));

            act.Should().Throw<StringException>()
               .And.Message.Should().Contain($"\"{invalidString}\" must be a substring of \"{text}\", but it is not.");
        }

        [Theory(DisplayName = "MustBeSubstringOf must not throw an exception when the specified string is substring of text.")]
        [InlineData("123", "123")]
        [InlineData("123", "1234")]
        [InlineData("bcd", "abcde")]
        [InlineData("I'll have you", "If you ever call me sister again, I'll have you strangled in your sleep.")]
        public void IsSubstring(string validString, string text)
        {
            var result = validString.MustBeSubstringOf(text);

            result.Should().BeSameAs(validString);
        }

        [Fact(DisplayName = "MustBeSubstringOf must throw an ArgumentNullException when text is null.")]
        public void TextNull()
        {
            Action act = () => "someText".MustBeSubstringOf(null);

            act.Should().Throw<ArgumentNullException>()
               .And.ParamName.Should().Be("text");
        }

        [Theory(DisplayName = "MustBeSubstringOf must not throw an exception when the specified string is a substring of text ingoring case-sensitivity.")]
        [InlineData("ABC", "abc")]
        [InlineData("NOBODY cares", "Nobody cares what your father once told you.")]
        public void CaseInsensitive(string validString, string text)
        {
            var result = validString.MustBeSubstringOf(text, true);

            result.Should().BeSameAs(validString);
        }

        void ICustomMessageAndExceptionTestDataProvider.PopulateTestDataForCustomExceptionAndCustomMessageTests(CustomMessageAndExceptionTestData testData)
        {
            testData.Add(new CustomExceptionTest(exception => "123".MustBeSubstringOf("42", exception: exception)))
                    .Add(new CustomMessageTest<StringException>(message => "abc".MustBeSubstringOf("cde", message: message)));
        }
    }
}