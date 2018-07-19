using System;

namespace Repozytorium.IRepo.VM
{
  public interface IZamowienie
  {
    int ZamowienieID { get; set; }
    int? KlientID { get; set; }
    DateTime? DataZamowienia { get; set; }
    decimal? CenaZamowienia { get; set; }
  }
}