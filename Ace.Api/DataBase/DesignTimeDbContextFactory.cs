using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ace.Shared.Config;

namespace Ace.Api.Database
{
    /// <summary>
    /// Creates database when performing migrations.
    /// </summary>
    public class DesignTimeDbContextFactory<TContext> : IDesignTimeDbContextFactory<TContext>
        where TContext : DbContext
    {
        public TContext CreateDbContext(string[] args)
        {
            //var configuration = new ConfigurationBuilder()
            //     .AddJsonFile("appsettings.Development.json")
            //     .AddEnvironmentVariables().Build();
            //var connectionString = configuration.GetConnectionString(typeof(TContext).Name);
            var connectionString = AceConfiguration.InstanceFactory.GetConnectionString("NoteAce");//"Server=(localdb)\\mssqllocaldb;Database=NoteAce;Trusted_Connection=True;MultipleActiveResultSets=true;"; // TODO later
            return (TContext)Activator.CreateInstance(typeof(TContext), new DbContextOptionsBuilder<TContext>().UseSqlServer(connectionString).Options);
        }
    }
}
