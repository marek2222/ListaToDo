using Repozytorium.Models;
using Repozytorium.Models.VM;
using Repozytorium.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Repozytorium.IRepo
{
  public interface IToDoContext
  {
    DbEntityEntry Entry(object entity);

    int SaveChanges();
    Database Database { get; }

    DbSet<Uzytkownik> Uzytkownik { get; set; }
    DbSet<Zadanie> Zadania { get; set; }

    DbSet<Klient> Klienci { get; set; }
    DbSet<Zamowienie> Zamowienia { get; set; }
    DbSet<KlientViewModel> KlienciViewModel { get; set; }
    DbSet<ZadanieViewModel> ZadaniaViewModel { get; set; }
  }
}