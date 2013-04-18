using System.Diagnostics;
using NUnit.Framework;

namespace Shouldly
{
    [DebuggerStepThrough]
    [ShouldlyMethods]
    public static class ShouldBeStringTestExtensions
    {
        /// <summary>
        /// Perform a string comparison, specifying the desired case sensitivity
        /// </summary>
        public static void ShouldBe(this string actual, string expected, Case caseSensitivity, string explaination = null)
        {
            var constraint = (caseSensitivity == Case.Sensitive)
                                 ? Is.EqualTo(expected)
                                 : Is.EqualTo(expected).IgnoreCase;
            actual.AssertAwesomely(constraint, actual, expected, explaination);
        }

        /// <summary>
        /// Strip out whitespace (whitespace, tabs, line-endings, etc) and compare the two strings
        /// </summary>
        public static void ShouldContainWithoutWhitespace(this string actual, object expected, string explaination = null)
        {
            var strippedActual = actual.Quotify().StripWhitespace();
            var strippedExpected = (expected ?? "NULL").ToString().Quotify().StripWhitespace();

            strippedActual.AssertAwesomely(Is.EqualTo(strippedExpected), actual, expected, explaination);
        }

        /// <summary>
        /// Strip out whitespace (whitespace, tabs, line-endings, etc) and compare the two strings
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        [System.Obsolete]
        public static void ShouldBeCloseTo(this string actual, object expected, string explaination = null)
        {
            ShouldContainWithoutWhitespace(actual, expected);
        }

        public static void ShouldStartWith(this string actual, string expected, string explaination = null)
        {
            actual.AssertAwesomely(Is.StringStarting(expected).IgnoreCase, actual, expected, explaination);
        }

        public static void ShouldEndWith(this string actual, string expected, string explaination = null)
        {
            actual.AssertAwesomely(Is.StringEnding(expected).IgnoreCase, actual, expected, explaination);
        }

        public static void ShouldContain(this string actual, string expected, string explaination = null)
        {
            actual.AssertAwesomely(Is.StringContaining(expected).IgnoreCase, actual.Clip(100), expected, explaination);
        }

        public static void ShouldNotContain(this string actual, string expected, string explaination = null)
        {
            actual.AssertAwesomely(Is.Not.StringContaining(expected).IgnoreCase, actual, expected, explaination);
        }

        public static void ShouldMatch(this string actual, string regexPattern, string explaination = null)
        {
            actual.AssertAwesomely(Is.StringMatching(regexPattern), actual, regexPattern, explaination);
        }
    }
}