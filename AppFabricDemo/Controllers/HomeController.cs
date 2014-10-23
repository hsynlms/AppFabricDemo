using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppFabricDemo.Classes;
using Microsoft.ApplicationServer.Caching;

namespace AppFabricDemo.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ViewResult Index()
        {
            List<DataCacheServerEndpoint> servers = new List<DataCacheServerEndpoint>();
            servers.Add(new DataCacheServerEndpoint("localhost", 22233));

            AppFabric demo = new AppFabric(servers);
            
            //prevent the exception.
            if (demo.GetData("hello") == null)
                demo.SetData("hello", "devleopers");

            ViewData.Add("Message", demo.GetData("hello"));

            return View();
        }

    }
}
