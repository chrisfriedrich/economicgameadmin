using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Economic_Game__Admin_.DAL;
using Economic_Game__Admin_.Models;

namespace Economic_Game__Admin_.Controllers
{
    [Authorize]
    public class GameSettingsController : Controller
    {
        private EconomicGameDataContext db = new EconomicGameDataContext();

        // GET: GameSettings
        public ActionResult Index()
        {
            return View(db.GameSettings.ToList());
        }

        // GET: GameSettings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameSettings gameSettings = db.GameSettings.Find(id);
            if (gameSettings == null)
            {
                return HttpNotFound();
            }
            return View(gameSettings);
        }

        // GET: GameSettings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameSettings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GameSettingsID,Name,Description,StartingAmount,Round1Multiplier,Round2Multiplier,Round3Multiplier,Round4Multiplier,Round1ReturnPercentage,Round2ReturnPercentage,Round3ReturnPercentage,Round4ReturnPercentage,ComputerApology,ComputerPersuasion,SelectedSettings")] GameSettings gameSettings)
        {
            if (ModelState.IsValid)
            {
                db.GameSettings.Add(gameSettings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gameSettings);
        }

        // GET: GameSettings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameSettings gameSettings = db.GameSettings.Find(id);
            if (gameSettings == null)
            {
                return HttpNotFound();
            }
            return View(gameSettings);
        }

        // POST: GameSettings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GameSettingsID,Name,Description,StartingAmount,Round1Multiplier,Round2Multiplier,Round3Multiplier,Round4Multiplier,Round1ReturnPercentage,Round2ReturnPercentage,Round3ReturnPercentage,Round4ReturnPercentage,ComputerApology,ComputerPersuasion,SelectedSettings")] GameSettings gameSettings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gameSettings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gameSettings);
        }

        // GET: GameSettings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameSettings gameSettings = db.GameSettings.Find(id);
            if (gameSettings == null)
            {
                return HttpNotFound();
            }
            return View(gameSettings);
        }

        // POST: GameSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GameSettings gameSettings = db.GameSettings.Find(id);
            db.GameSettings.Remove(gameSettings);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SetDefault(int id)
        {
            GameSettings existingDefault = db.GameSettings.FirstOrDefault(x => x.SelectedSettings == true);
            if (existingDefault != null)
            {
                existingDefault.SelectedSettings = false;
                db.Entry(existingDefault).State = EntityState.Modified;
                db.SaveChanges();
            }

            GameSettings newDefault = db.GameSettings.Find(id);
            if (newDefault != null)
            {
                newDefault.SelectedSettings = true;
                db.Entry(newDefault).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");   
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
