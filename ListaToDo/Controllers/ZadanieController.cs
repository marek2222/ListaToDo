﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repozytorium.Models;
using Repozytorium.Repo;
using Repozytorium.IRepo;

namespace ListaToDo.Controllers
{
  public class ZadanieController : Controller
  {
    private readonly IZadanieRepo _repo;
    public ZadanieController(IZadanieRepo repo)
    {
      _repo = repo;
    }

    // GET: Zadanie
    public ActionResult Index()
    {
      var zadania = _repo.PobierzZadania();
      return View(zadania.ToList());
    }

    // GET: Zadanie/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Zadanie zadanie = _repo.PobierzZadaniePrzezID(id);
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
        Opis50zWielokropkiem(zadanie);
        try
        {
          _repo.Dodaj(zadanie);
          _repo.SaveChanges();
          return RedirectToAction("Index");
          //return RedirectToAction("MojeZadania");
        }
        catch (Exception ex)
        {
          return View(zadanie);
        }
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
      Zadanie zadanie = _repo.PobierzZadaniePrzezID(id);
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
        Opis50zWielokropkiem(zadanie);
        _repo.Aktualizuj(zadanie);
        _repo.SaveChanges();
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
      Zadanie zadanie = _repo.PobierzZadaniePrzezID(id);
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
      _repo.UsunZadanie(id);
      try
      {
        _repo.SaveChanges();
      }
      catch (Exception ex)
      {
        return RedirectToAction("Delete", new { id = id, blad = true });
      }
      return RedirectToAction("Index");
    }

    //protected override void Dispose(bool disposing)
    //{
    //  if (disposing)
    //  {
    //    db.Dispose();
    //  }
    //  base.Dispose(disposing);
    //}

    private void Opis50zWielokropkiem(Zadanie zadanie)
    {
      if (zadanie.Opis.Length > 50)
        zadanie.Opis = zadanie.Opis.Substring(0, 50) + "...";
    }

  }
}
