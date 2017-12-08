using System;
using FluentAssertions;
using Light.GuardClauses.Tests.CustomMessagesAndExceptions;
using Xunit;

namespace Light.GuardClauses.Tests.ComparableAssertionsTests
{
    public sealed class MustNotBeInTests : ICustomMessageAndExceptionTestDataProvider
    {
        [Theory(DisplayName = "MustNotBeIn must throw an exception when the specified value is inside of range (with inclusive lower boundary and exclusive upper boundary).")]
        [InlineData(1, 1, 5)]
        [InlineData(2, 1, 5)]
        [InlineData(4, 1, 5)]
        [InlineData('b', 'b', 'f')]
        [InlineData('c', 'b', 'f')]
        [InlineData('e', 'b', 'f')]
        public void ParameterWithinInclusiveLowerAndExclusiveUpperBoundary(int value, int lowerBoundary, int upperBoundary)
        {
            Action act = () => value.MustNotBeIn(Range<int>.FromInclusive(lowerBoundary).ToExclusive(upperBoundary), nameof(value));

            act.ShouldThrow<ArgumentOutOfRangeException>()
               .And.Message.Should().Contain($"{nameof(value)} must not be between {lowerBoundary} (inclusive) and {upperBoundary} (exclusive), but you specified {value}.");
        }

        [Theory(DisplayName = "MustNotBeIn must throw an exception when the specified value is inside of range (with exclusive lower boundary and inclusive upper boundary).")]
        [InlineData(2, 1, 5)]
        [InlineData(4, 1, 5)]
        [InlineData(5, 1, 5)]
        [InlineData('c', 'b', 'f')]
        [InlineData('d', 'b', 'f')]
        [InlineData('f', 'b', 'f')]
        public void ParameterWithinExclusiveLowerAndInclusiveUpperBoundary(short value, short lowerBoundary, short upperBoundary)
        {
            Action act = () => value.MustNotBeIn(Range<short>.FromExclusive(lowerBoundary).ToInclusive(upperBoundary), nameof(value));

            act.ShouldThrow<ArgumentOutOfRangeException>()
               .And.Message.Should().Contain($"{nameof(value)} must not be between {lowerBoundary} (exclusive) and {upperBoundary} (inclusive), but you specified {value}.");
        }

        [Theory(DisplayName = "MustNotBeIn must not throw an exception when the specified value is outside of the range.")]
        [InlineData(9, 10, 20, true, true)]
        [InlineData(21, 10, 20, true, true)]
        [InlineData(20, 10, 20, true, false)]
        [InlineData(10, 10, 20, false, false)]
        [InlineData(181, 10, 20, false, false)]
        public void ParameterOutOfRange(int value, int lowerBoundary, int upperBoundary, bool isLowerBoundaryInclusive, bool isUpperBoundaryInclusive)
        {
            var range = new Range<int>(lowerBoundary, upperBoundary, isLowerBoundaryInclusive, isUpperBoundaryInclusive);
            var result = value.MustNotBeIn(range, nameof(value));

            result.Should().Be(value);
        }

        void ICustomMessageAndExceptionTestDataProvider.PopulateTestDataForCustomExceptionAndCustomMessageTests(CustomMessageAndExceptionTestData testData)
        {
            testData.Add(new CustomExceptionTest(exception => 30.MustNotBeIn(Range<int>.FromInclusive(30).ToExclusive(35), exception: exception)))
                    .Add(new CustomMessageTest<ArgumentOutOfRangeException>(message => 42.MustNotBeIn(Range<int>.FromInclusive(40).ToExclusive(50), message: message)));
        }
    }
}