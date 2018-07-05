using System.Collections.Generic;
using Repozytorium.Models;
using System.Linq;

namespace Repozytorium.IRepo
{
  public interface IZadanieRepo
  {
    IQueryable<Zadanie> PobierzZadania();
    Zadanie PobierzZadaniePrzezID(int? id);

    void Dodaj(Zadanie zadanie);
    void Aktualizuj(Zadanie zadanie);
    void UsunZadanie(int id);
    void SaveChanges();
  }
}