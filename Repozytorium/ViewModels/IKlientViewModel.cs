using Repozytorium.IRepo;
using System;

namespace Repozytorium.ViewModels
{
  public interface IKlientViewModel
  {
    int ID { get; set; }
    string Addres { get; set; }
    decimal? CenaZamowienia { get; set; }
    DateTime? DataZamowienia { get; set; }
    string Komorka { get; set; }
    string Nazwa { get; set; }
  }
}