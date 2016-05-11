using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProjetFinalEval.Controllers
{
    public class TacheController : Controller
    {
        bd_evaluationEntities3 bd = new bd_evaluationEntities3();
        // GET: Tache
        public ActionResult Index()
        {
            return View(bd.tache.ToList());
        }

        // GET: Tache/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tache/Create
        public ActionResult Create()
        {
            ViewBag.Collaborateur = new SelectList(bd.collaborateurtitulaire, "IDCOLLABORATEURTITULAIRE", "NOM");
            ViewBag.Projet = new SelectList(bd.projet, "IDPROJET", "NOMPROJET");
            return View();
        }

        // POST: Tache/Create
        [HttpPost]
        public ActionResult Create(tache Tache, FormCollection fc)
        {
            var testid = fc["DATEFINTACHE"];
        
          
            try
            {
                // TODO: Add insert logic here

                ViewBag.Collaborateur=new SelectList(bd.collaborateurtitulaire,"IDCOLLABORATEURTITULAIRE","NOM"+" "+"PRENOM");
                ViewBag.Projet = new SelectList(bd.projet, "IDPROJET", "NOMPROJET");
                if(ModelState.IsValid){
                    bd.tache.Add(Tache);
                    bd.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(Tache);
            }
            catch
            {
                return View();
            }
        }

        // GET: Tache/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tache/Edit/5
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

        // GET: Tache/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tache Tache = bd.tache.Find(id);
            if (Tache == null)
            {
                return HttpNotFound();
            }
            return View(Tache);
        }

        // POST: Tache/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id,tache T)
        {
            try
            {
                tache Tache = new tache();
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    Tache = bd.tache.Find(id);
                    if (Tache == null)
                        return HttpNotFound();
                    bd.tache.Remove(Tache);
                    bd.SaveChanges();
                    // TODO: Add delete logic here
                    return RedirectToAction("Index");
                }
                return View(Tache);
            }

            catch
            {
                return View();
            }
        }
    }
}
