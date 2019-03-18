﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Fibon.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                            .AddEnvironmentVariables()
                            .AddCommandLine(args)
                            .Build();
            WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(config)
                .UseStartup<Startup>()
                .UseUrls("http://localhost:5050")
                .UseKestrel(options=>{
                    options.Limits.MaxRequestBodySize = null;
                })
                .Build()
                .Run();
        }
    }
}
