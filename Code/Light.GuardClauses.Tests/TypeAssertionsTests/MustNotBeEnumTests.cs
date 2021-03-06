using System;
using System.Reflection;
using FluentAssertions;
using Light.GuardClauses.Exceptions;
using Light.GuardClauses.Tests.CustomMessagesAndExceptions;
using Xunit;

namespace Light.GuardClauses.Tests.TypeAssertionsTests
{
    public sealed class MustNotBeEnumTests : ICustomMessageAndExceptionTestDataProvider
    {
        [Fact(DisplayName = "MustNotBeEnum must throw a TypeException when the specified type is an enum.")]
        public void IsEnum()
        {
            TestIsEnum(() => typeof(ConsoleColor).MustNotBeEnum(), typeof(ConsoleColor));
            TestIsEnum(() => typeof(BindingFlags).GetTypeInfo().MustNotBeEnum(), typeof(BindingFlags));
        }

        private static void TestIsEnum(Action act, Type type)
        {
            act.Should().Throw<TypeException>()
               .And.Message.Should().Contain($"The type \"{type}\" must not be an enum, but it is.");
        }

        [Fact(DisplayName = "MustNotBeEnum must not throw an exception when the specified type is no enum.")]
        public void IsNotEnum()
        {
            typeof(int).MustNotBeEnum().Should().Be(typeof(int));
            typeof(IEquatable<string>).GetTypeInfo().MustNotBeEnum().Should().Be(typeof(IEquatable<string>).GetTypeInfo());
        }

        [Fact(DisplayName = "MustNotBeEnum must throw an ArgumentNullException when parameter is null.")]
        public void ParameterNull()
        {
            new Action(() => ((Type) null).MustNotBeEnum()).Should().Throw<ArgumentNullException>();
            new Action(() => ((TypeInfo) null).MustNotBeEnum()).Should().Throw<ArgumentNullException>();
        }


        void ICustomMessageAndExceptionTestDataProvider.PopulateTestDataForCustomExceptionAndCustomMessageTests(CustomMessageAndExceptionTestData testData)
        {
            testData.AddExceptionTest(exception => typeof(ConsoleColor).MustNotBeEnum(exception: exception))
                    .AddMessageTest<TypeException>(message => typeof(ConsoleColor).MustNotBeEnum(message: message));

            testData.AddExceptionTest(exception => typeof(GCCollectionMode).GetTypeInfo().MustNotBeEnum(exception: exception))
                    .AddMessageTest<TypeException>(message => typeof(AttributeTargets).GetTypeInfo().MustNotBeEnum(message: message));
        }
    }
}