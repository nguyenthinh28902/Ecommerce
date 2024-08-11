﻿using Authentication.DataAccess.DataDefault;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Service.DependencyInjections
{
    public static class RegisterServiceProvider
    {
        public static IServiceProvider ServiceProvider(this IServiceProvider serviceProvider)
        {
            SeedData.InitializeAsync(serviceProvider).Wait();
            return serviceProvider;

        }

    }
}
