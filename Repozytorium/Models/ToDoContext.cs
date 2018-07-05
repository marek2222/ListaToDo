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

namespace Repozytorium.Models
{
  // You can add profile data for the user by adding more properties to your Uzytkownik class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
  public class Uzytkownik : IdentityUser
  {
    public Uzytkownik()
    {
    }
    // Klucz podstawowy odziedziczony po klasie IdentityUser    
    // Dodajemy pola Imie i Nazwisko    
    public string Imie { get; set; }
    public string Nazwisko { get; set; }

    #region dodatkowe pole notmapped    
    [NotMapped]
    [Display(Name = "Pan/Pani:")]
    public string PelneNazwisko { get { return Imie + " " + Nazwisko; } }
    #endregion

    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Uzytkownik> manager)
    {
      // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
      var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
      // Add custom user claims here
      return userIdentity;
    }
  }


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
    }
  }
}