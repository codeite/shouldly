using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using System;

namespace Shouldly
{
    [DebuggerStepThrough]
    [ShouldlyMethods]
    public static class ShouldBeTestExtensions
    {
        public static void ShouldBe<T>(this T actual, T expected, string explaination = null)
        {
            actual.AssertAwesomely(Is.EqualTo(expected), actual, expected, explaination);
        }

        public static void ShouldBeTypeOf<T>(this object actual, string explaination = null)
        {
            ShouldBeTypeOf(actual, typeof(T));
        }

        public static void ShouldBeTypeOf(this object actual, Type expected, string explaination = null)
        {
            actual.AssertAwesomely(Is.InstanceOf(expected), actual.GetType(), expected, explaination);
        }

        public static void ShouldNotBeTypeOf<T>(this object actual, string explaination = null)
        {
            ShouldNotBeTypeOf(actual, typeof(T));
        }

        public static void ShouldNotBeTypeOf(this object actual, Type expected, string explaination = null)
        {
            actual.AssertAwesomely(!Is.InstanceOf(expected), actual, expected, explaination);
        }

        public static void ShouldNotBe<T>(this T actual, T expected, string explaination = null)
        {
            actual.AssertAwesomely(Is.Not.EqualTo(expected), actual, expected, explaination);
        }

        public static void ShouldBe(this float actual, float expected, double tolerance, string explaination = null)
        {
            actual.AssertAwesomely(Is.EqualTo(expected).Within(tolerance), actual, expected, explaination);
        }

        public static void ShouldBe(this IEnumerable<double> actual, IEnumerable<double> expected, double tolerance, string explaination = null)
        {
            actual.AssertAwesomely(Is.EqualTo(expected).Within(tolerance), actual, expected, explaination);
        }

        public static void ShouldBe(this IEnumerable<float> actual, IEnumerable<float> expected, double tolerance, string explaination = null)
        {
            actual.AssertAwesomely(Is.EqualTo(expected).Within(tolerance), actual, expected, explaination);
        }

        public static void ShouldBe(this double actual, double expected, double tolerance, string explaination = null)
        {
            actual.AssertAwesomely(Is.EqualTo(expected).Within(tolerance), actual, expected, explaination);
        }

        public static void ShouldBe(this decimal actual, decimal expected, decimal tolerance, string explaination = null)
        {
            actual.AssertAwesomely(Is.EqualTo(expected).Within(tolerance), actual, expected, explaination);
        }

        public static void ShouldBe(this IEnumerable<decimal> actual, IEnumerable<decimal> expected, decimal tolerance, string explaination = null)
        {
            actual.AssertAwesomely(Is.EqualTo(expected).Within(tolerance), actual, expected, explaination);
        }

        public static void ShouldBeGreaterThan(this object actual, object expected, string explaination = null)
        {
            actual.AssertAwesomely(Is.GreaterThan(expected), actual, expected, explaination);
        }

        public static void ShouldBeGreaterThanOrEqualTo(this object actual, object expected, string explaination = null)
        {
            actual.AssertAwesomely(Is.GreaterThanOrEqualTo(expected), actual, expected, explaination);
        }

        public static void ShouldBeLessThan(this object actual, object expected, string explaination = null)
        {
            actual.AssertAwesomely(Is.LessThan(expected), actual, expected, explaination);
        }

        public static void ShouldBeSameAs(this object actual, object expected, string explaination = null)
        {
            actual.AssertAwesomely(Is.SameAs(expected), actual, expected, explaination);
        }

        public static void ShouldNotBeSameAs(this object actual, object expected, string explaination = null)
        {
            actual.AssertAwesomely(Is.Not.SameAs(expected), actual, expected, explaination);
        }
    }
}