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
        public ActionResult Details(int? id)
        {
            if(id==null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            tache Tache = new tache();
            Tache = bd.tache.Find(id);
            return View(Tache);
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
        public ActionResult Edit(int? id)
        {
            ViewBag.Collaborateur = new SelectList(bd.collaborateurtitulaire, "IDCOLLABORATEURTITULAIRE", "NOM");
            ViewBag.Projet = new SelectList(bd.projet, "IDPROJET", "NOMPROJET");
            if(id==null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            tache Tache = bd.tache.Find(id);
            if (Tache == null)
                return HttpNotFound();
            return View(Tache);
        }

        // POST: Tache/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,tache Tache)
        {
            ViewBag.Collaborateur = new SelectList(bd.collaborateurtitulaire, "IDCOLLABORATEURTITULAIRE", "NOM");
            ViewBag.Projet = new SelectList(bd.projet, "IDPROJET", "NOMPROJET");
            tache T = bd.tache.Find(id);
            T.IDTACHE = id;
            T.NOMTACHE=Tache.NOMTACHE;
            T.DATEDEBUTTACHE = Tache.DATEDEBUTTACHE;
            T.DATEFINTACHE = Tache.DATEFINTACHE;
            T.IDPROJET = Tache.IDPROJET;
            T.IDCOLLABORATEURTITULAIRE = Tache.IDCOLLABORATEURTITULAIRE;
            T.collaborateurtitulaire = bd.collaborateurtitulaire.Single(m=>m.IDCOLLABORATEURTITULAIRE==Tache.IDCOLLABORATEURTITULAIRE);
            T.projet = bd.projet.Single(m => m.IDPROJET == Tache.IDPROJET);
            try
            {

                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    bd.Entry(T).State = System.Data.Entity.EntityState.Modified;
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
