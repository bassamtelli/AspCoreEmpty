using System;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreEmpty
{
	public class HomeController:Controller
    {
        public IActionResult Index()
        {
            return new ContentResult { Content = "Home.Index" };
        }
    }
}
