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
    public class SpecModel : PageModel
    {
        private readonly ILogger<SpecModel> _logger;

        public SpecModel(ILogger<SpecModel> logger)
        {
            _logger = logger;
        }


        public void OnGet()
        {
            //return Partial();
        }
    }
}
