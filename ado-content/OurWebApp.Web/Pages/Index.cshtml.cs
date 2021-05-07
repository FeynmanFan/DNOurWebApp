using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace OurWebApp.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration Config;

        public string KeyVaultName
        {
            get
            {
                return Config.GetValue<string>("KeyVaultName");
            }
        }

        // Constructor that that takes IConfiguration is called on instantiation thanks to Dependency injection
        public IndexModel(IConfiguration config)
        {
            Config = config;
        }

        public void OnGet()
        {

        }
    }
}
