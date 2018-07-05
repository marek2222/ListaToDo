using Repozytorium.IRepo;
using Repozytorium.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Repozytorium.Repo
{
  public class ZadanieRepo : IZadanieRepo
  {
    private readonly IToDoContext _db;

    public ZadanieRepo(IToDoContext db)
    {
      _db = db;
    }

    public IQueryable<Zadanie> PobierzZadania()
    {
      //_db.Database.Log = message => System.Diagnostics.Trace.WriteLine(message);
      // pobranie natychmiast danych
      //return db.Zadania.ToList();

      // odroczone (opóźnione) wykonanie (ang. Deferred Execution)
      return _db.Zadania.AsNoTracking();
    }

    public Zadanie PobierzZadaniePrzezID(int? id)
    {
      return _db.Zadania.Find(id);
    }

    public void Dodaj(Zadanie zadanie)
    {
      _db.Zadania.Add(zadanie);
    }

    public void Aktualizuj(Zadanie zadanie)
    {
      _db.Entry(zadanie).State = EntityState.Modified;
    }

    public void UsunZadanie(int id)
    {
      Zadanie zadanie = PobierzZadaniePrzezID(id);
      _db.Zadania.Remove(zadanie);
    }

    public void SaveChanges()
    {
      _db.SaveChanges();
    }

  }
}