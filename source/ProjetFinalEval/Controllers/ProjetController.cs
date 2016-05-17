using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProjetFinalEval.Controllers
{
    public class ProjetController : Controller
    {
        private bd_evaluationEntities3 bd = new bd_evaluationEntities3();
        // GET: Projet
        public ActionResult Index()
        {
            return View(bd.projet.ToList());
        }

        // GET: Projet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            projet pr = bd.projet.Find(id);
            if (pr == null)
                return HttpNotFound();


            return View(pr);
        }

        // GET: Projet/Create
        public ActionResult Create()
        {
            ViewBag.collaborateurtitulaire = new SelectList(bd.collaborateurtitulaire, "IDCOLLABORATEURTITULAIRE", "NOM");
            ViewBag.collaborateurpe = new SelectList(bd.collaborateurpe, "IDCOLLABORATEURPE", "NOMPE");
            ViewBag.client = new SelectList(bd.client, "IDCLIENT", "ABREVIATION");

            return View();
        }

        // POST: Projet/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "collaborateurtitulaire,collaborateurpe")]projet Projet, FormCollection fc)
        {
           var testid = fc["collaborateurpe"];
           string[] testids = testid.Split(',');
           foreach (var item in testids)
           {
               int b = int.Parse(item);
               Projet.collaborateurpe.Add(bd.collaborateurpe.Where(m => m.IDCOLLABORATEURPE == b).FirstOrDefault());
           }
           var testid1 = fc["collaborateurtitulaire"];
            string[] tt=testid1.Split(',');
            foreach(var item in tt){
                int b = int.Parse(item);
                Projet.collaborateurtitulaire.Add(bd.collaborateurtitulaire.Where(m => m.IDCOLLABORATEURTITULAIRE == b).FirstOrDefault());

            }
          
              
           
           
           
           ViewBag.collaborateurtitulaire = new MultiSelectList(bd.collaborateurtitulaire, "IDCOLLABORATEURTITULAIRE", "NOM");
            ViewBag.collaborateurpe = new MultiSelectList(bd.collaborateurpe, "IDCOLLABORATEURPE", "NOMPE");
            ViewBag.client = new SelectList(bd.client, "IDCLIENT", "ABREVIATION");
            Projet.client = bd.client.Single(m => m.IDCLIENT == Projet.IDCLIENT);
            try
            {
                // TODO: Add insert logic here
                
                if (ModelState.IsValid) {
                   
                    var y = bd.projet.Add(Projet);
                    bd.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Projet/Edit/5
        public ActionResult Edit(int? id)
        {

            ViewBag.collaborateurtitulaire = new MultiSelectList(bd.collaborateurtitulaire, "IDCOLLABORATEURTITULAIRE", "NOM");
            var vv = "";
            var tab = bd.projet.Find(id).collaborateurpe ;
            for (int i = 0; i < tab.Count(); i++)
            {
                vv += tab.ElementAtOrDefault(i).NOMPE ;
            }
            ViewBag.collaborateurpe = new MultiSelectList(bd.collaborateurpe, "IDCOLLABORATEURPE", "NOMPE");
            ViewBag.IDCLIENT = new SelectList(bd.client, "IDCLIENT", "ABREVIATION", bd.projet.Find(id).client.IDCLIENT);
           

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            projet col = bd.projet.Find(id);
            
            if (col == null)
                return HttpNotFound();
            return View(col);
        }

        // POST: Projet/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, [Bind(Exclude = "collaborateurtitulaire,collaborateurpe")]projet pro, FormCollection fc)
        {

            ViewBag.collaborateurtitulaire = new MultiSelectList(bd.collaborateurtitulaire, "IDCOLLABORATEURTITULAIRE", "NOM");
            ViewBag.collaborateurpe = new MultiSelectList(bd.collaborateurpe, "IDCOLLABORATEURPE", "NOMPE");
            ViewBag.IDCLIENT = new SelectList(bd.client, "IDCLIENT", "ABREVIATION");

            projet p = bd.projet.Find(id);
            p.IDPROJET =(int) id;
            p.NOMPROJET = pro.NOMPROJET;
            p.DATEDEBUT = pro.DATEDEBUT;
            p.DATEFIN = pro.DATEFIN;
            p.TYPE = pro.TYPE;
            p.IDCLIENT = pro.IDCLIENT;
            p.client = bd.client.Single(m => m.IDCLIENT == pro.IDCLIENT);
            p.FLAGTYPE = pro.FLAGTYPE;
            var testid = fc["collaborateurpe"];
            string[] testids = testid.Split(',');
            p.collaborateurpe.Clear();
            foreach (var item in testids)
            {
                int b = int.Parse(item);
                p.collaborateurpe.Add(bd.collaborateurpe.Where(m => m.IDCOLLABORATEURPE == b).FirstOrDefault());
            }
            var testid1 = fc["collaborateurtitulaire"];
            string[] tt = testid1.Split(',');
            p.collaborateurtitulaire.Clear();
            foreach (var item in tt)
            {
                int b = int.Parse(item);
                p.collaborateurtitulaire.Add(bd.collaborateurtitulaire.Where(m => m.IDCOLLABORATEURTITULAIRE == b).FirstOrDefault());

            }




            try
            {
                if (ModelState.IsValid)
                {
                    bd.Entry(p).State = System.Data.Entity.EntityState.Modified;

                   

                    bd.SaveChanges();
                    return RedirectToAction("Index");


                }
                return View(p);
            }
            catch
            {
                return View();
            }
        }

        // GET: Projet/Delete/5
        public ActionResult Delete(int? id)
        {
            projet bb=bd.projet.Find(id);
            var x = "";
                                if (bb.TYPE == 2) { x = "Regi"; }
                                else if (bb.TYPE == 1) { x = "Thema"; }
                                else { x = "yyy"; }

                                ViewBag.Type = x;
           var z = "";
           if (bb.FLAGTYPE == true){
               z = "Interne";
           }
           else{
               z = "Externe";
           } ViewBag.flag = z;

           ViewBag.datedebut = bb.DATEDEBUT.Value.Day.ToString() + "/" + bb.DATEDEBUT.Value.Month.ToString() + "/" + bb.DATEDEBUT.Value.Year.ToString();
           ViewBag.datedefin = bb.DATEFIN.Value.Day.ToString() + "/" + bb.DATEFIN.Value.Month.ToString() + "/" + bb.DATEFIN.Value.Year.ToString();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            projet colpe = bd.projet.Find(id);
            if (colpe == null)
            {
                return HttpNotFound();
            }
            return View(colpe);
        }

        // POST: Projet/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, projet pro)
        {
            try
            {
                projet colpe = new projet();
              
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                    colpe = bd.projet.Find(id);
                    
                    if (colpe == null)
                        return HttpNotFound();


                    bd.projet.Remove(colpe);
                    
                    bd.SaveChanges();
                    return RedirectToAction("Index");

                } return View(colpe);
            }
            catch
            {
                return View();
            }
        }
    }
}
