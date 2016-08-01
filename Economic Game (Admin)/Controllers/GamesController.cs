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
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Economic_Game__Admin_.Controllers
{
    [Authorize]
    public class GamesController : Controller
    {
        private EconomicGameDataContext db = new EconomicGameDataContext();

        // GET: Games
        public ActionResult Index()
        {
            return View(db.Games.ToList());
        }

        // GET: Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GameID,PlayerName,AmazonID,StartingAmount,CurrentRound,Round1Multiplier,Round2Multiplier,Round3Multiplier,Round4Multiplier,Round1ReturnPercentage,Round2ReturnPercentage,Round3ReturnPercentage,Round4ReturnPercentage,Round1Investment,Round1Kept,Round1Returned,Round2Investment,Round2Kept,Round2Returned,Round3Investment,Round3Kept,Round3Returned,Round4Investment,Round4Kept,Round4Returned,PlayerTotal,ComputerTotal,ComputerPersuasion,ComputerApology,GameSettingsID")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(game);
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GameID,PlayerName,AmazonID,StartingAmount,CurrentRound,Round1Multiplier,Round2Multiplier,Round3Multiplier,Round4Multiplier,Round1ReturnPercentage,Round2ReturnPercentage,Round3ReturnPercentage,Round4ReturnPercentage,Round1Investment,Round1Kept,Round1Returned,Round2Investment,Round2Kept,Round2Returned,Round3Investment,Round3Kept,Round3Returned,Round4Investment,Round4Kept,Round4Returned,PlayerTotal,ComputerTotal,ComputerPersuasion,ComputerApology,GameSettingsID")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        // GET: Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ExportToExcel()
        {
            //var products = new System.Data.DataTable("teste");
            //products.Columns.Add("col1", typeof(int));
            //products.Columns.Add("col2", typeof(string));

            //products.Rows.Add(1, "product 1");
            //products.Rows.Add(2, "product 2");
            //products.Rows.Add(3, "product 3");
            //products.Rows.Add(4, "product 4");
            //products.Rows.Add(5, "product 5");
            //products.Rows.Add(6, "product 6");
            //products.Rows.Add(7, "product 7");


            var grid = new GridView();
            grid.DataSource = db.Games.ToList();
            grid.DataBind();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=GameData" + DateTime.Now.ToShortDateString() + ".xls");
            Response.ContentType = "application/ms-excel";

            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);

            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

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
