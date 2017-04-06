using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XamarinOAuth2Demo.Web.Controllers
{
    [Authorize]
    public class OrarioController : Controller
    {
        // GET: Orario
        public ActionResult Index()
        {
            return Content(DateTime.Now.ToString());
        }
    }
}