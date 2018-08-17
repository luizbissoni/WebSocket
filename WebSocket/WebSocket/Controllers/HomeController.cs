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

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> HelloWorld(string mensagem)
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

            var result = await pusher.TriggerAsync("my-own-chanel", "my-event", new {
                message = mensagem
            });

            return new HttpStatusCodeResult((int)HttpStatusCode.OK);
        }

    }
}