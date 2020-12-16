using E_Class.DAL.DALModel;
using E_Class.Models.Class_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Class.Controllers.ControllerClass
{
    public class ProfesoriController : Controller
    {
        // GET: Profesori
        public ActionResult Index()
        {
            // return View(DAL.DALModel.GrupiDAL.List());
            return View(DAL.DALModel.ProfesoratDAL.List());
        }

        // GET: Profesori/Details/5
        public ActionResult Details(int id)
        {
            Profesori profesori = ProfesoratDAL.Read(id);
            return View("Details",profesori);
        }

        // GET: Profesori/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profesori/Create
        [HttpPost]
        public ActionResult Create(Profesori profesori)
        {

            profesori.CreatedOn = DateTime.Now;
            if (ProfesoratDAL.Insert(profesori))
            {
                return Redirect("Index");
            }
            return Redirect("Index");
         

        }

        // GET: Profesori/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Profesori/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Profesori collection)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {

                    ProfesoratDAL.Update(collection,id);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View("Index");
            }
        }

        // GET: Profesori/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Profesori/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Profesori profesori)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProfesoratDAL.Delete(id);
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }
    }
}
