using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OurWebApp.Data;

namespace OurWebApp.Web.Pages
{
    public class MenuModel : PageModel
    {
        public List<Dessert> Desserts 
        { 
            get
            {
                return Db.Desserts;
            } 
        }

        public void OnGet()
        {
        }
    }
}
