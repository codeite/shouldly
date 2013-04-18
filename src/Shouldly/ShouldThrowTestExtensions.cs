using System;
using System.Diagnostics;

namespace Shouldly
{
    [DebuggerStepThrough]
    [ShouldlyMethods]
    public static class Should
    {
        public static TException Throw<TException>(Action actual, string explaination = null) where TException : Exception
        {
            try
            {
                actual();
            }
            catch (TException e)
            {
                return e;
            }
            catch (Exception e)
            {
                throw new ChuckedAWobbly(new ShouldlyMessage(typeof(TException), e.GetType()).ToString(), explaination);
            }

            throw new ChuckedAWobbly(new ShouldlyMessage(typeof(TException)).ToString(), explaination);
        }

        public static void NotThrow(Action action, string explaination = null)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                throw new ChuckedAWobbly(new ShouldlyMessage(ex.GetType()).ToString(), explaination);
            }
        }
    }
}