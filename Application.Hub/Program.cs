using System;
using System.Collections.Generic;
using Application.Hub.Infrastructure.Environment.Enums;
using Application.Utilities.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Application.Hub
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureHostConfiguration(builder =>
                {
                    KeyValuePair<string, string> environment = new(HostDefaults.EnvironmentKey,
                        Environment.GetEnvironmentVariable(EnvironmentVariableKey.AspNetCoreEnvironment.GetEnumMemberAttrValue())!);

                    builder.AddInMemoryCollection(new[] { environment })
                        .AddEnvironmentVariables();
                })
                .ConfigureWebHostDefaults(builder =>
                {
                    builder.UseStartup<Startup>();
                });
    }
}
