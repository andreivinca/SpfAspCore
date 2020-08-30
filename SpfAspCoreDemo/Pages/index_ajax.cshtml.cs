using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;

namespace SpfAspCoreDemo.Pages
{
    public class indexAjaxModel : PageModel
    {
        public int random;

        public void OnGet()
        {
            random = new Random().Next(0, 100);
        }
    }
}
