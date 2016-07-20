﻿using System;
using System.Collections.Generic;
using System.Linq;
using CodeTiger;
using Xunit;

namespace UnitTests.CodeTiger
{
    public class EnumerableExtensionsTests
    {
        public class AnyNot_IEnumerableOfTSource_FuncOfTSourceAndBoolean
        {
            [Fact]
            public void ThrowsArgumentNullExceptionWhenSourceIsNull()
            {
                List<int> target = null;
                Func<int, bool> predicate = element => true;

                Assert.Throws<ArgumentNullException>("source",
                    () => EnumerableExtensions.AnyNot(target, predicate));
            }

            [Fact]
            public void ThrowsArgumentNullExceptionWhenPredicateIsNull()
            {
                var target = new List<int>();
                Func<int, bool> predicate = null;

                Assert.Throws<ArgumentNullException>("predicate",
                    () => EnumerableExtensions.AnyNot(target, predicate));
            }

            [Theory]
            [InlineData(true)]
            [InlineData(false)]
            public void ReturnsFalseWhenSourceContainsNoElements(bool predicateResult)
            {
                var target = new List<int>();
                Func<int, bool> predicate = element => predicateResult;

                Assert.False(EnumerableExtensions.AnyNot(target, predicate));
            }

            [Theory]
            [InlineData(1)]
            [InlineData(2)]
            [InlineData(100)]
            public void ReturnsFalseWhenSourceContainsElementsAndPredicateAlwaysReturnsTrue(int numberOfElements)
            {
                var target = Enumerable.Range(0, numberOfElements)
                    .Select(x => x * 2);

                Func<int, bool> predicate = element => true;

                Assert.False(EnumerableExtensions.AnyNot(target, predicate));
            }

            [Theory]
            [InlineData(2)]
            [InlineData(100)]
            public void ReturnsTrueWhenSourceContainsElementsAndPredicateReturnsTrueForFirstItem(
                int numberOfElements)
            {
                var target = Enumerable.Range(0, numberOfElements)
                    .Select(x => x * 2);

                Func<int, bool> predicate = element => element == 0;

                Assert.True(EnumerableExtensions.AnyNot(target, predicate));
            }

            [Theory]
            [InlineData(2)]
            [InlineData(100)]
            public void ReturnsTrueWhenSourceContainsElementsAndPredicateReturnsTrueForLastItem(
                int numberOfElements)
            {
                var target = Enumerable.Range(0, numberOfElements)
                    .Select(x => x * 2);

                Func<int, bool> predicate = element => element == (numberOfElements - 1) * 2;

                Assert.True(EnumerableExtensions.AnyNot(target, predicate));
            }

            [Theory]
            [InlineData(1)]
            [InlineData(2)]
            [InlineData(100)]
            public void ReturnsTrueWhenSourceContainsElementsAndPredicateAlwaysReturnsFalse(int numberOfElements)
            {
                var target = new List<int>();
                Func<int, bool> predicate = element => false;

                for (int i = 0; i < numberOfElements; i++)
                {
                    target.Add(i);
                }

                Assert.True(EnumerableExtensions.AnyNot(target, predicate));
            }
        }
    }
}
