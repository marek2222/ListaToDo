using System;
using System.ComponentModel.DataAnnotations;

namespace Repozytorium.Models
{
  public enum StatusZadania { Wykonane = 1, Niewykonane = 0 };

  public class Zadanie
  {
    public Zadanie() { }

    [Display(Name = "Id:")]
    public int Id { get; set; }

    [Required]
    [Display(Name = "Nazwa zadania"), MaxLength(50)]
    public string Nazwa { get; set; }

    [Display(Name = "Opis zadania"), MaxLength(2000)]
    public string Opis { get; set; }

    [Required]
    [Display(Name = "Termin wykonania"), DataType(DataType.DateTime)]
    //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? Termin { get; set; }

    // wykonane- true, niewykonane - false
    public bool Status { get; set; }

    //- Nazwa zadania(max 50zn, pole obowiązkowe)
    //- opis zadania(max. 2000 zn, pole nieobwiązkowe)
    //- Termin wykonania(data i czas wykonania, pole nieobowiązkowe)
    //- Status(wykonane/niewykonane)
  }

}