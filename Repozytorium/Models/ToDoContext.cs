using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using Repozytorium.IRepo;
using Repozytorium.Models.VM;

namespace Repozytorium.Models
{
  public class ToDoContext : IdentityDbContext, IToDoContext
  {
    public ToDoContext()
        : base("DefaultConnection")
    {
    }

    public static ToDoContext Create()
    {
      return new ToDoContext();
    }

    public DbSet<Uzytkownik> Uzytkownik { get; set; }
    public DbSet<Zadanie> Zadania { get; set; }

    public DbSet<Klient> Klienci { get; set; }
    public DbSet<Zamowienie> Zamowienia { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      // Potrzebne dla klas Identity    
      base.OnModelCreating(modelBuilder);
      // using System.Data.Entity.ModelConfiguration.Conventions;    
      // Wyłącza konwencję, która automatycznie tworzy liczbę mnogą dla nazw tabel     
      // w bazie danych    

      // Zamiast Kategorie zostałaby stworzona tabela o nazwie Kategories    
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
      // Wyłącza konwencję CascadeDelete    
      // CascadeDelete zostanie włączone za pomocą Fluent API    
      modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
      //// Używa się Fluent API, aby ustalić powiązanie pomiędzy tabelami    
      //// i włączyć CascadeDelete dla tego powiązania    
      //modelBuilder.Entity<Ogloszenie>().HasRequired(x => x.Uzytkownik).WithMany(x => x.Ogloszenia)
      //.HasForeignKey(x => x.UzytkownikId)
      //.WillCascadeOnDelete(true);
      modelBuilder.Entity<Klient>().Property(e => e.Nazwa).IsUnicode(false);
      modelBuilder.Entity<Klient>().Property(e => e.Addres).IsUnicode(false);
      modelBuilder.Entity<Klient>().Property(e => e.Komorka).IsUnicode(false);
      modelBuilder.Entity<Klient>().Property(e => e.EmailID).IsUnicode(false);
      modelBuilder.Entity<Zamowienie>().Property(e => e.CenaZamowienia).HasPrecision(18, 0);

    }

    public System.Data.Entity.DbSet<Repozytorium.ViewModels.KlientViewModel> KlientViewModels { get; set; }
  }
}