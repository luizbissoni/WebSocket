using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PusherServer;
using System.Web.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace WebSocket.Controllers
{
    public class SecondController : Controller
    {
        // GET: Second
        public ActionResult Index()
        {
            return View();
        }


        public class HelloWorldController : Controller
        {
            [HttpPost]
            public async Task<ActionResult> HelloWorld()
            {
                var options = new PusherOptions
                {
                    Cluster = "us2",
                    Encrypted = true
                };

                var pusher = new Pusher(
                  "580199",
                  "78ade9e19befaaecf09c",
                  "daf7bc7d66d990f23172",
                  options);

                var result = await pusher.TriggerAsync(
                  "my-channel",
                  "my-event",
                  new { message = "hello world" });

                return new HttpStatusCodeResult((int)HttpStatusCode.OK);
            }
        }
    }
}