using System.Reflection;

namespace Isg.Shared.Extensions
{
    public static class AssemblyExtensions
    {
        /// <summary>
        /// Gets product and file version information for the assembly as an identifier.
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static string GetIdentifier(this Assembly assembly)
        {
            return $"{assembly.GetCustomAttribute<AssemblyProductAttribute>().Product} " +
                $"{assembly.GetCustomAttribute<AssemblyFileVersionAttribute>().Version}";
        }
    }
}
