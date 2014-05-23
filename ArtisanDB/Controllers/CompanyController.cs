using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtisanDB.Models;
using System.Net;
using System.IO;


namespace ArtisanDB.Controllers
{
    public class CompanyController : Controller
    {
        private ArtisanDBContext db = new ArtisanDBContext();

        //
        // GET: /Company/

        public ActionResult Index()
        {
            return View(db.Companies.ToList());
        }

        //
        // GET: /Company/Details/5

        public ActionResult Details(int id = 0)
        {
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        //
        // GET: /Company/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Company/Create

        [HttpPost]
        public ActionResult Create(Company company)
        {
            if (ModelState.IsValid)
            {
                db.Companies.Add(company);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(company);
        }

        //
        // GET: /Company/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        //
        // POST: /Company/Edit/5

        [HttpPost]
        public ActionResult Edit(Company company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(company);
        }

        //
        // GET: /Company/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        //
        // POST: /Company/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = db.Companies.Find(id);
            db.Companies.Remove(company);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        // Get
        public ActionResult SearchIndex (String searchStr)
        {
            var companies = from c in db.Companies
                            select c;

            if (!String.IsNullOrEmpty(searchStr))
            {
                
                companies = companies.Where(s => s.name.Contains(searchStr) || s.stockname.Contains(searchStr));
                return View(companies);
            }
            return View(companies);
        }

        public ActionResult Update(String urlReq)
        {
            //var companies = from c in db.Companies
            //                select c;
            if(true)
            {
                if (urlReq != null)
                {
                    String htmlCode = "Error";
                    using (WebClient client = new WebClient())
                    {
                        htmlCode = client.DownloadString(urlReq);
                    }
                    ViewBag.sourceCode = HttpUtility.HtmlEncode(htmlCode);
                } 
            }
            return View();
        }

        // Post, naturally
        [HttpPost]
        public string SearchIndex(FormCollection fc, string searchString)
        {
            return "<h3>From [HttpPost]SearchIndex: " + searchString + "</h3>";
        }
    }
}