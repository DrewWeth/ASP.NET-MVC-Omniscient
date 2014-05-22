using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;


namespace ArtisanDB.Controllers
{
    public class HelloWorldController : Controller
    {
        //
        // GET: /HelloWorld/

        public ActionResult Index() //index implicitly root
        {
            //return "This is my <b>default</b> action...";
            return View(); // ?? implicit what?
        }

        public ActionResult Welcome(String name, int numTimes = 1) //extended from index
        {
            ArrayList greetings = new ArrayList();
            greetings.Add("Bonjour");
            greetings.Add("Hello");
            greetings.Add("Hola");

            Random r = new Random();
            var n = r.Next() % greetings.Count -1;
            ViewBag.greeting = greetings[n] + " " + name;
            ViewBag.numTimes = numTimes;
            //return "This is the welcome actyion method./..";
            //return HttpUtility.HtmlEncode("Sup " + name + ". You've been here " + numTimes + " times son.");
            return View();
        }

    }
}
