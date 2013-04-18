using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Shouldly
{
    [DebuggerStepThrough]
    [ShouldlyMethods]
    public static class ShouldBeEnumerableTestExtensions
    {
        public static void ShouldContain<T>(this IEnumerable<T> actual, T expected, string explaination = null)
        {
            if (!actual.Contains(expected))
                throw new ChuckedAWobbly(new ShouldlyMessage(expected, actual).ToString(), explaination);
        }

        public static void ShouldNotContain<T>(this IEnumerable<T> actual, T expected, string explaination = null)
        {
            if (actual.Contains(expected))
                throw new ChuckedAWobbly(new ShouldlyMessage(expected, actual).ToString(), explaination);
        }

        public static void ShouldContain<T>(this IEnumerable<T> actual, Expression<Func<T, bool>> elementPredicate, string explaination = null)
        {
            var condition = elementPredicate.Compile();
            if (!actual.Any(condition))
                throw new ChuckedAWobbly(new ShouldlyMessage(elementPredicate.Body).ToString(), explaination);
        }

        public static void ShouldNotContain<T>(this IEnumerable<T> actual, Expression<Func<T, bool>> elementPredicate, string explaination = null)
        {
            var condition = elementPredicate.Compile();
            if (actual.Any(condition))
                throw new ChuckedAWobbly(new ShouldlyMessage(elementPredicate.Body).ToString(), explaination);
        }

        public static void ShouldBeEmpty<T>(this IEnumerable<T> actual, string explaination = null)
        {
            if (actual == null || (actual != null && actual.Count() != 0))
                throw new ChuckedAWobbly(new ShouldlyMessage(actual).ToString(), explaination);
        }

        public static void ShouldNotBeEmpty<T>(this IEnumerable<T> actual, string explaination = null)
        {
            if (actual == null || actual != null && actual.Count() == 0)
                throw new ChuckedAWobbly(new ShouldlyMessage(actual).ToString(), explaination);
        }

        public static void ShouldContain(this IEnumerable<float> actual, float expected, double tolerance, string explaination = null) 
        {
            if (actual.Where(a => Math.Abs(expected - a) < tolerance).Count() < 1)
                throw new ChuckedAWobbly(new ShouldlyMessage(expected, actual).ToString(), explaination);
        }

        public static void ShouldContain(this IEnumerable<double> actual, double expected, double tolerance, string explaination = null) 
        {
            if (actual.Where(a => Math.Abs(expected - a) < tolerance).Count() < 1)
                throw new ChuckedAWobbly(new ShouldlyMessage(expected, actual).ToString(), explaination);
        }
    }

}