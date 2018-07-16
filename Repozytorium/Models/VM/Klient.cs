namespace Repozytorium.Models.VM
{
  using System;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;

  public class Klient
  {
    [Key]
    [Required]
    public int KlientID { get; set; }

    [StringLength(100)]
    public string Nazwa { get; set; }

    [StringLength(300)]
    public string Addres { get; set; }

    [StringLength(15)]
    public string Komorka { get; set; }

    public DateTime? DataUrodzenia { get; set; }

    [StringLength(300)]
    public string EmailID { get; set; }
  }
}
