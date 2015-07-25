using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_oa_new.Controllers
{
    public class DeparmentController : Controller
    {
        // GET: Deparment
        public ActionResult Index()
        {
            return View();
        }

        // GET: Deparment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Deparment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deparment/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Deparment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Deparment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Deparment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Deparment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
