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
            Lenda lenda = LendaDAL.Read(id);
            return View("Details",lenda);
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
            return View(LendaDAL.Read(id));
        }

        // POST: Lenda/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Lenda collection)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {

                    LendaDAL.Update(collection, id);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");

            }
            catch(Exception ex)
            {
                return View("Index");
            }
        }

        // GET: Lenda/Delete/5
        public ActionResult Delete(int id)
        {
            return View(LendaDAL.Read(id));
        }

        // POST: Lenda/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Lenda lenda)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                LendaDAL.Delete(id);
                return RedirectToAction("Index",lenda);
                // }

                
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
