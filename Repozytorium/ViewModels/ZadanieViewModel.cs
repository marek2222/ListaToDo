using Repozytorium.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Repozytorium.ViewModels
{
  public class ZadanieViewModel : BaseModel, IZadanieViewModel
  {
    [Required]
    [Display(Name = "Nazwa zadania"), MaxLength(50)]
    public string Nazwa { get; set; }

    [Required]
    [Display(Name = "Termin wykonania"), DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? Termin { get; set; }

    public bool Status { get; set; }

  }
}