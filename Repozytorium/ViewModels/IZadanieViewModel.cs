using Repozytorium.IRepo;
using Repozytorium.Models;
using System;

namespace Repozytorium.ViewModels
{
  public interface IZadanieViewModel : IBaseModel
  { 
    string Nazwa { get; set; }
    bool Status { get; set; }
    DateTime? Termin { get; set; }
  }
}