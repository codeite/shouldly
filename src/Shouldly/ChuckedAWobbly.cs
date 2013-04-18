using System;

namespace Shouldly
{
    internal class ChuckedAWobbly : Exception
    {
        public ChuckedAWobbly(string message, string explaination) : base(BuildMessage(message, explaination))
        {
        }

        private static string BuildMessage(string message, string explaination)
        {
            if (explaination != null)
            {
                message += "\nExplination: " + explaination;
            }

            return message;
        }
    }
}