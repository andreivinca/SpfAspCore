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
    public class Demo5Model : PageModel
    {
        private readonly ILogger<Demo5Model> _logger;

        public Demo5Model(ILogger<Demo5Model> logger)
        {
            _logger = logger;
        }


        public void OnGet()
        {
            //return Partial();
        }
    }
}
