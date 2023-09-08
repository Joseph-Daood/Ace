using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ace.Shared.Config
{
    public class AceConfiguration : IAceConfiguration
    {
        /// <summary>
        /// http://csharpindepth.com/Articles/General/Singleton.aspx
        /// </summary>
        private static readonly Lazy<AceConfiguration> Lazy = new Lazy<AceConfiguration>(() => new AceConfiguration());

        public static AceConfiguration InstanceFactory => Lazy.Value;

        public IConfiguration Configuration { get; private set; }

        private AceConfiguration()
        {
             Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddInMemoryCollection(new Dictionary<string, string>
            {
                    {"TestHost:UseWebpackDevMiddleware", "false"}
            })
            .Build();
        }

        public string? this[string key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IEnumerable<IConfigurationSection> GetChildren()
        {
            return Configuration.GetChildren();
        }

        public IChangeToken GetReloadToken()
        {
            return Configuration.GetReloadToken();
        }

        public IConfigurationSection GetSection(string key)
        {
            return Configuration.GetSection(key);
        }
    }
}
