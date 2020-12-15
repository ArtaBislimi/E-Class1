using E_Class.DAL.DALModel;
using E_Class.Models.Class_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Class.Controllers.ControllerClass
{
    public class SallatController : Controller
    {
        // GET: Sallat
        public ActionResult Index()
        {
            return View(DAL.DALModel.SallatDAL.List());
        }

        // GET: Sallat/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sallat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sallat/Create
        [HttpPost]
        public ActionResult Create(Salla salla)
        {
            try
            {
                // TODO: Add insert logic here
                salla.CreatedOn = DateTime.Now;
                if (SallatDAL.Insert(salla))
                {
                    return Redirect("Index");
                }
                return View(salla);
            }
            catch
            {
                return View();
            }
        }

        // GET: Sallat/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sallat/Edit/5
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

        // GET: Sallat/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sallat/Delete/5
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
