using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace SpfAspCoreDemo.Pages
{
    public class Demo1Model : PageModel
    {
        private readonly ILogger<Demo1Model> _logger;

        public Demo1Model(ILogger<Demo1Model> logger)
        {
            _logger = logger;
        }


        public void OnGet()
        {
            //return Partial();
        }
    }
}
