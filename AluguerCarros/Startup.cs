﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AluguerCarros.Startup))]
namespace AluguerCarros
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
