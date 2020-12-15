using E_Class.DAL.DALModel;
using E_Class.Models.Class_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Class.Controllers.ControllerClass
{
    public class LendaController : Controller
    {
        // GET: Lenda
        public ActionResult Index()
        {
            // return View(DAL.DALModel.GrupiDAL.List());
            return View(DAL.DALModel.LendaDAL.List());
        }

        // GET: Lenda/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Lenda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lenda/Create
        [HttpPost]
        public ActionResult Create(Lenda lenda)
        {
                lenda.CreatedOn = DateTime.Now;
                if (LendaDAL.Insert(lenda))
                {
                    return Redirect("Index");
                }
                return View(lenda);
          
        }

        // GET: Lenda/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Lenda/Edit/5
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

        // GET: Lenda/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Lenda/Delete/5
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
