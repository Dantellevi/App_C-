using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net;

using System.Threading.Tasks;

namespace ASPController.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<string> Hello(string name)
        {
            string UserName = await Task.Factory.StartNew(()=> JsonConvert.DeserializeObject<string>(name));
            return await Task.Factory.StartNew(()=>JsonConvert.SerializeObject(string.Format("Hello!!!{0} ", UserName)));
        }
    }
}