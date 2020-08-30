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
    public class Demo4Model : PageModel
    {
        private readonly ILogger<Demo4Model> _logger;

        public Demo4Model(ILogger<Demo4Model> logger)
        {
            _logger = logger;
        }


        public void OnGet()
        {
            //return Partial();
        }
    }
}
