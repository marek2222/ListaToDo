using Repozytorium.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Repozytorium.IRepo
{
  public interface IToDoContext
  {
    DbEntityEntry Entry(object entity);

    DbSet<Uzytkownik> Uzytkownik { get; set; }
    DbSet<Zadanie> Zadania { get; set; }

    int SaveChanges();
    Database Database { get; }
  }
}