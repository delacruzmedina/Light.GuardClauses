﻿using System;
using System.Collections.Generic;
using FluentAssertions;
using Light.GuardClauses.Exceptions;
using Light.GuardClauses.Tests.CustomMessagesAndExceptions;
using Xunit;

namespace Light.GuardClauses.Tests.EnumerableAssertionsTests
{
    public sealed class MustContainInstancesOfDifferentTypesTests : ICustomMessageAndExceptionTestDataProvider
    {
        private static readonly List<IInterface> ValidTestData = new List<IInterface>
                                                                 {
                                                                     new A(),
                                                                     new B(),
                                                                     new C()
                                                                 };

        private static readonly List<IInterface> InvalidTestData = new List<IInterface>
                                                                   {
                                                                       new A(),
                                                                       new B(),
                                                                       new A(),
                                                                       new C()
                                                                   };

        [Fact(DisplayName = "MustContainInstancesOfDifferentTypes must throw a CollectionException when the specified collection contains instances of the same type.")]
        public void ListWithInstancesOfSameType()
        {
            Action act = () => InvalidTestData.MustContainInstancesOfDifferentTypes(nameof(InvalidTestData));

            act.Should().Throw<CollectionException>()
               .And.Message.Should().Contain($"{nameof(InvalidTestData)} must contain instances of different subtypes, but \"{typeof(A)}\" occurs a second time at index \"{2}\".");
        }

        [Fact(DisplayName = "MustContainInstancesOfDifferentTypes must not throw an exception when the specified collection contains instances of different subtypes.")]
        public void ListWithDifferentInstances()
        {
            var result =  ValidTestData.MustContainInstancesOfDifferentTypes();

            result.Should().BeSameAs(ValidTestData);
        }

        [Fact(DisplayName = "MustContainInstancesOfDifferentTypes must throw an ArgumentNullException when the specified collection is null.")]
        public void CollectionNull()
        {
            Action act = () => ((IEnumerable<object>) null).MustContainInstancesOfDifferentTypes();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact(DisplayName = "MustContainInstancesOfDifferentTypes must throw a CollectionException when the specified collection contains null.")]
        public void CollectionContainsNull()
        {
            var collectionWithNull = new IInterface[] { new A(), null, new C() };

            Action act = () => collectionWithNull.MustContainInstancesOfDifferentTypes();

            act.Should().Throw<CollectionException>()
               .And.Message.Should().Contain("The collection contains null at index 1.");
        }

        void ICustomMessageAndExceptionTestDataProvider.PopulateTestDataForCustomExceptionAndCustomMessageTests(CustomMessageAndExceptionTestData testData)
        {
            testData.Add(new CustomExceptionTest(exception => InvalidTestData.MustContainInstancesOfDifferentTypes(exception: exception)))
                    .Add(new CustomMessageTest<CollectionException>(message => InvalidTestData.MustContainInstancesOfDifferentTypes(message: message)));
        }

        private interface IInterface { }

        private class A : IInterface { }

        private class B : IInterface { }

        private class C : A { }
    }
}