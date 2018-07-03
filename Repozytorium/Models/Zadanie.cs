using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repozytorium.Models
{
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

    [Display(Name = "Termin wykonania"), DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:MM tt}", ApplyFormatInEditMode = true)]
    public System.DateTime Termin { get; set; }

    // wykonane- 1, niewykonane - 0)
    public bool Status { get; set; }

    //- Nazwa zadania(max 50zn, pole obowiązkowe)
    //- opis zadania(max. 2000 zn, pole nieobwiązkowe)
    //- Termin wykonania(data i czas wykonania, pole nieobowiązkowe)
    //- Status(wykonane/niewykonane)
  }
}