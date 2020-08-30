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
    public class Demo3Model : PageModel
    {
        private readonly ILogger<Demo3Model> _logger;

        public Demo3Model(ILogger<Demo3Model> logger)
        {
            _logger = logger;
        }


        public void OnGet()
        {
            //return Partial();
        }
    }
}
