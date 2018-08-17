using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PusherServer;
using System.Threading.Tasks;
using System.Net;


namespace WebSocket.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpPost]
        public async Task<ActionResult> HelloWorld()
        {
            var options = new PusherOptions
            {
                Cluster = "u2",
                Encrypted = true
            };

            var pusher = new Pusher(
               "580199",
               "78ade9e19befaaecf09c",
               "daf7bc7d66d990f23172",
                    options);

            var result = await pusher.TriggerAsync("my-channel", "my-event", new { message = "Hello World"  });

            return new HttpStatusCodeResult((int)HttpStatusCode.OK);
        }

    }
}