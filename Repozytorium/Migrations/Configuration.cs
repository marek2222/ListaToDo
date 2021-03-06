namespace Repozytorium.Migrations
{
  using Microsoft.AspNet.Identity;
  using Microsoft.AspNet.Identity.EntityFramework;
  using Models;
  using Models.VM;
  using System;
  using System.Data.Entity.Migrations;
  using System.Linq;

  internal sealed class Configuration : DbMigrationsConfiguration<Repozytorium.Models.ToDoContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = true;
      AutomaticMigrationDataLossAllowed = true;
    }

    protected override void Seed(Repozytorium.Models.ToDoContext context)
    {
      // Do debugowania metody seed    
      //if (System.Diagnostics.Debugger.IsAttached == false)
      //  System.Diagnostics.Debugger.Launch();
      SeedRoles(context);
      SeedUsers(context);
      SeedZadania(context);
      SeedKlienci(context);
      SeedZamowienia(context);
    }

    private void SeedRoles(ToDoContext context)
    {
      var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());

      if (!roleManager.RoleExists("Admin"))
      {
        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        role.Name = "Admin";
        roleManager.Create(role);
      }
      if (!roleManager.RoleExists("Pracownik"))
      {
        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        role.Name = "Pracownik";
        roleManager.Create(role);
      }
    }

    private void SeedUsers(ToDoContext context)
    {
      var store = new UserStore<Uzytkownik>(context);
      var manager = new UserManager<Uzytkownik>(store);
      if (!context.Users.Any(u => u.UserName == "admin@o2.pl"))
      {
        var user = new Uzytkownik { UserName = "admin@o2.pl"}; 
        var adminresult = manager.Create(user, "12345678");
        if (adminresult.Succeeded)
          manager.AddToRole(user.Id, "Admin");
      }

      if (!context.Users.Any(u => u.UserName == "marek@o2.pl"))
      {
        var user = new Uzytkownik { UserName = "marek@o2.pl" };
        var adminresult = manager.Create(user, "12345678,");
        if (adminresult.Succeeded)
          manager.AddToRole(user.Id, "Pracownik");
      }
    }

    private void SeedZadania(ToDoContext context)
    {
      var idUzytkownika = context.Set<Uzytkownik>().Where(u => u.UserName == "admin@o2.pl").FirstOrDefault().Id;
      for (int i = 1; i <= 5; i++)
      {
        var zad = new Zadanie()
        {
          Id = i,
          Nazwa = "Zadanie" + i.ToString(),
          Opis = "Opis zadania" + i.ToString(),
          Termin = DateTime.Now.AddDays(-i),
          Status = (((i % 2 + 2) % 2 == 0) ? true : false)
        };
        context.Set<Zadanie>().AddOrUpdate(zad);
      }
      context.SaveChanges();
    }


    private void SeedKlienci(ToDoContext context)
    {
      for (int i = 1; i <= 5; i++)
      {
        var klient = new Klient()
        {
          KlientID = i,
          Nazwa  = "darek" + i.ToString(),
          Addres = "Lodz_" + i.ToString(),
          Komorka = "12345678" + i.ToString(),
          DataUrodzenia = DateTime.Now.AddDays(-i - 40),
          EmailID = "darek" + i.ToString() + "@o2.pl"
        };
        context.Set<Klient>().AddOrUpdate(klient);
      }
      context.SaveChanges();
    }

    private void SeedZamowienia(ToDoContext context)
    {
      for (int i = 1; i <= 3; i++)
      {
        var zam = new Zamowienie()
        {
          ZamowienieID = i,
          KlientID = i,
          DataZamowienia = DateTime.Now.AddDays(-i),
          CenaZamowienia = 1000 * i
        };
        context.Set<Zamowienie>().AddOrUpdate(zam);
      }
      context.SaveChanges();
    }

  }
}

