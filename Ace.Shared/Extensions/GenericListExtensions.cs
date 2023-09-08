using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Isg.Shared.Extensions
{
    /// <summary>
    /// https://stackoverflow.com/questions/18667633/how-can-i-use-async-with-foreach
    /// </summary>
    public static class GenericListExtensions
    {
        public static async Task ForEachAsync<T>(this IEnumerable<T> list, Func<T, Task> func)
        {
            if (list == null)
            {
                return;
            }
            foreach (var value in list)
            {
                await func(value);
            }
        }
    }
}
