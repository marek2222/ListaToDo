using Repozytorium.IRepo;
using System.ComponentModel.DataAnnotations;

namespace Repozytorium.Models
{
  public class BaseModel : IBaseModel
  {
    [Display(Name = "Id:")]
    public int Id { get; set; }
  }
}