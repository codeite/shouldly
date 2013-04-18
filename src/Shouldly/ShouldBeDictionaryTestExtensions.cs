using System.Collections.Generic;
using System.Diagnostics;

namespace Shouldly 
{
    [DebuggerStepThrough]
    [ShouldlyMethods]
    public static class ShouldBeDictionaryTestExtensions 
    {
        public static void ShouldContainKey<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, string explaination = null) 
        {
            if (!dictionary.ContainsKey(key))
                throw new ChuckedAWobbly(new ShouldlyMessage(key).ToString(), explaination);
        }

        public static void ShouldContainKeyAndValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue val, string explaination = null) 
        {
            if (!dictionary.ContainsKey(key))
                throw new ChuckedAWobbly(new ShouldlyMessage(key).ToString(), explaination);

            if (!dictionary[key].Equals(val))
                throw new ChuckedAWobbly(new ShouldlyMessage(val, dictionary[key]).ToString(), explaination);
        }

        public static void ShouldNotContainKey<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, string explaination = null) 
        {
            if (dictionary.ContainsKey(key))
                throw new ChuckedAWobbly(new ShouldlyMessage(key).ToString(), explaination);
        }

        public static void ShouldNotContainValueForKey<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue val, string explaination = null) 
        {
            if (!dictionary.ContainsKey(key))
                throw new ChuckedAWobbly(new ShouldlyMessage(key).ToString(), explaination);

            if (dictionary[key].Equals(val))
                throw new ChuckedAWobbly(new ShouldlyMessage(dictionary[key], val).ToString(), explaination);
        }
    }
}
