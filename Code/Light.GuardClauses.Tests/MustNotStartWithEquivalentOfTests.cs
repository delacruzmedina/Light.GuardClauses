﻿using System;
using FluentAssertions;
using Light.GuardClauses.Exceptions;
using Light.GuardClauses.Tests.CustomMessagesAndExceptions;
using Xunit;

namespace Light.GuardClauses.Tests
{
    [Trait("Category", Traits.FunctionalTests)]
    public sealed class MustNotStartWithEquivalentOfTests : ICustomMessageAndExceptionTestDataProvider
    {
        [Theory(DisplayName = "MustNotStartWithEquivalentOf must throw a StringException when the string starts with the specified text (ignoring case-sensitivity).")]
        [InlineData("Hello", "Hell")]
        [InlineData("Foo", "foo")]
        [InlineData("PASSWORD", "PaSsWOrd")]
        [InlineData("You love your children. It's your one redeeming quality; that and your cheekbones.", "you love your children")]
        public void StartTextEqual(string @string, string startText)
        {
            Action act = () => @string.MustNotStartWithEquivalentOf(startText, nameof(@string));

            act.ShouldThrow<StringException>()
               .And.Message.Should().Contain($"{nameof(@string)} must not start with the equivalent of \"{startText}\", but you specified {@string}.");
        }

        [Theory(DisplayName = "MustNotStartWithEquivalentOf must not throw an exception when the string does not start with the specified text (ignoring case-sensitivity).")]
        [InlineData("Hello", "World")]
        [InlineData("Foo", "Bar")]
        [InlineData("As impossible as it seems, there was once a time I was unaccustomed to wine.", "I was unaccustomed")]
        public void StartTextDifferent(string @string, string startText)
        {
            Action act = () => @string.MustNotStartWithEquivalentOf(startText);

            act.ShouldNotThrow();
        }

        [Theory(DisplayName = "MustNotStartWithEquivalentOf must throw an ArgumentNullException when parameter or text is null.")]
        [InlineData(null, "Foo")]
        [InlineData("Foo", null)]
        public void ArgumentNull(string @string, string startText)
        {
            Action act = () => @string.MustNotStartWithEquivalentOf(startText);

            act.ShouldThrow<ArgumentNullException>();
        }

        public void PopulateTestDataForCustomExceptionAndCustomMessageTests(CustomMessageAndExceptionTestData testData)
        {
            testData.Add(new CustomExceptionTest(exception => "Foo".MustNotStartWithEquivalentOf("foo", exception: exception)));

            testData.Add(new CustomMessageTest<StringException>(message => "Foo".MustNotStartWithEquivalentOf("foo", message: message)));
        }
    }
}