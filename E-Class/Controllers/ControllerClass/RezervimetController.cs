using E_Class.DAL.DALModel;
using E_Class.Models.Class_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Class.Controllers.ControllerClass
{
    public class RezervimetController : Controller
    {
        // GET: Rezervimet
        public ActionResult Index()
        {
            return View(DAL.DALModel.RezervimetDAL.List());
        }

        // GET: Rezervimet/Details/5
        public ActionResult Details(int id)
        {
            Rezervimet rezervimet = RezervimetDAL.Read(id);
            return View("Details",rezervimet);
        }

        // GET: Rezervimet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rezervimet/Create
        [HttpPost]
        public ActionResult Create(Rezervimet rezervimet)
        {
            rezervimet.CreatedOn = DateTime.Now;
            if (RezervimetDAL.Insert(rezervimet))
            {
                return Redirect("Index");
            }
            return Redirect("Index");
        }

        // GET: Rezervimet/Edit/5
        public ActionResult Edit(int id)
        {
            return View(RezervimetDAL.Read(id));
        }

        // POST: Rezervimet/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Rezervimet rezervimet)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    RezervimetDAL.Update(rezervimet, id);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rezervimet/Delete/5
        public ActionResult Delete(int id)
        {
            return View(RezervimetDAL.Read(id));
        }

        // POST: Rezervimet/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Rezervimet rezervimet)
        {
            try
            {
                // TODO: Add delete logic here
                ProfesoratDAL.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
