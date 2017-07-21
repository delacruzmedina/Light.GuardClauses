using System;
using System.ComponentModel;
using System.Reflection;
using FluentAssertions;
using Light.GuardClauses.Exceptions;
using Light.GuardClauses.Tests.CustomMessagesAndExceptions;
using Xunit;

namespace Light.GuardClauses.Tests.TypeAssertionsTests
{
    [Trait("Category", Traits.FunctionalTests)]
    public sealed class MustNotBeDelegateTests : ICustomMessageAndExceptionTestDataProvider
    {
        [Fact(DisplayName = "MustNotBeDelegate must throw a TypeException when the specified type is a delegate.")]
        public void IsDelegate()
        {
            TestIsDelegate(() => typeof(Action).MustNotBeDelegate(), typeof(Action));
            TestIsDelegate(() => typeof(EventHandler).GetTypeInfo().MustNotBeDelegate(), typeof(EventHandler));
        }

        private static void TestIsDelegate(Action act, Type type)
        {
            act.ShouldThrow<TypeException>()
               .And.Message.Should().Contain($"The type \"{type}\" must not be a delegate, but it is.");
        }

        [Fact(DisplayName = "MustNotBeDelegate must not throw an exception when the specified type is no delegate.")]
        public void IsNotDelegate()
        {
            TestIsNotDelegate(() => typeof(int).MustNotBeDelegate());
            TestIsNotDelegate(() => typeof(string).GetTypeInfo().MustNotBeDelegate());
        }

        private static void TestIsNotDelegate(Action act)
        {
            act.ShouldNotThrow();
        }

        [Fact(DisplayName = "MustNotBeDelegate must throw an ArgumentNullException when parameter is null.")]
        public void ParameterNull()
        {
            new Action(() => ((Type) null).MustNotBeDelegate()).ShouldThrow<ArgumentNullException>();
            new Action(() => ((TypeInfo) null).MustNotBeDelegate()).ShouldThrow<ArgumentNullException>();
        }

        public void PopulateTestDataForCustomExceptionAndCustomMessageTests(CustomMessageAndExceptionTestData testData)
        {
            testData.AddExceptionTest(exception => typeof(Action).MustNotBeDelegate(exception: exception))
                    .AddMessageTest<TypeException>(message => typeof(Func<>).MustNotBeDelegate(message: message));

            testData.AddExceptionTest(exception => typeof(PropertyChangedEventHandler).GetTypeInfo().MustNotBeDelegate(exception: exception))
                    .AddMessageTest<TypeException>(message => typeof(AsyncCallback).GetTypeInfo().MustNotBeDelegate(message: message));
        }
    }
}