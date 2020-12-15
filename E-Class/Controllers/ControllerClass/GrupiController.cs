using E_Class.DAL.DALModel;
using E_Class.Models.Class_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace E_Class.Controllers
{
    public class GrupiController : Controller
    {
        // GET: Grupi
        public ActionResult Index()
        {
            return View(DAL.DALModel.GrupiDAL.List());
        }

        // GET: Grupi/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupi grupi = GrupiDAL.Read(id);
            if (grupi == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        // GET: Grupi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Grupi/Create
        [HttpPost]
        public ActionResult Create(Grupi grupi)
        {
            grupi.CreatedOn = DateTime.Now;
            if (GrupiDAL.Insert(grupi))
            {
                return Redirect("Index");
            }
            return View(grupi);
        }

        // GET: Grupi/Edit/5
        public ActionResult Edit(int id)
        {
            //return View();
            return View();
        }

        // POST: Grupi/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Grupi grupi)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    GrupiDAL.Update(grupi);
                    return RedirectToAction("Index");
                }
                return View(grupi);
            }
            catch
            {
                return View();
            }
        }

        // GET: Grupi/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Grupi/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                GrupiDAL.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
