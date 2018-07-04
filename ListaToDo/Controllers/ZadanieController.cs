using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repozytorium.Models;

namespace ListaToDo.Controllers
{
  public class ZadanieController : Controller
  {
    private ToDoContext db = new ToDoContext();

    // GET: Zadanie
    public ActionResult Index()
    {
      return View(db.Zadania.ToList());
    }

    // GET: Zadanie/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Zadanie zadanie = db.Zadania.Find(id);
      if (zadanie == null)
      {
        return HttpNotFound();
      }
      return View(zadanie);
    }

    // GET: Zadanie/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: Zadanie/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "Id,Nazwa,Opis,Termin,Status")] Zadanie zadanie)
    {
      if (ModelState.IsValid)
      {
        if (zadanie.Opis.Length > 50)
          zadanie.Opis = zadanie.Opis.Substring(0, 50) + "...";
        db.Zadania.Add(zadanie);
        db.SaveChanges();
        return RedirectToAction("Index");
      }

      return View(zadanie);
    }

    // GET: Zadanie/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Zadanie zadanie = db.Zadania.Find(id);
      if (zadanie == null)
      {
        return HttpNotFound();
      }
      return View(zadanie);
    }

    // POST: Zadanie/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "Id,Nazwa,Opis,Termin,Status")] Zadanie zadanie)
    {
      if (ModelState.IsValid)
      {
        if (zadanie.Opis.Length > 50)
          zadanie.Opis = zadanie.Opis.Substring(0, 50) + "...";
        db.Entry(zadanie).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(zadanie);
    }

    // GET: Zadanie/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Zadanie zadanie = db.Zadania.Find(id);
      if (zadanie == null)
      {
        return HttpNotFound();
      }
      return View(zadanie);
    }

    // POST: Zadanie/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Zadanie zadanie = db.Zadania.Find(id);
      db.Zadania.Remove(zadanie);
      db.SaveChanges();
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
