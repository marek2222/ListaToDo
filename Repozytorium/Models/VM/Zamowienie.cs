namespace Repozytorium.Models.VM
{
  using IRepo.VM;
  using System;
  using System.ComponentModel.DataAnnotations;

  public class Zamowienie : IZamowienie
  {
    [Key]
    [Required]
    public int ZamowienieID { get; set; }
    public int? KlientID { get; set; }
    public DateTime? DataZamowienia { get; set; }
    public decimal? CenaZamowienia { get; set; }
  }
}
