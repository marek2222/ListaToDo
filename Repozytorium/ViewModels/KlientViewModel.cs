using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repozytorium.ViewModels
{
  public class KlientViewModel
  {
    [Key]
    public int ID { get; set; }

    // Klient
    [StringLength(100)]
    public string Nazwa { get; set; }

    [StringLength(300)]
    public string Addres { get; set; }

    [StringLength(15)]
    public string Komorka { get; set; }

    // Zamowienie
    public DateTime? DataZamowienia { get; set; }

    public decimal? CenaZamowienia { get; set; }
  }
}