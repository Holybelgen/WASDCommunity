using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wasd.Controllers
{
    [Authorize]
    public class StreamsController : Controller
    {
        //
        // GET: /Streams/
        public ActionResult Streams()
        {
            return View();
        }
	}
}