﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

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
}