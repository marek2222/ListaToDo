using System;

namespace Repozytorium.IRepo.VM
{
  public interface IKlient
  {
    string Addres { get; set; }
    DateTime? DataUrodzenia { get; set; }
    string EmailID { get; set; }
    int KlientID { get; set; }
    string Komorka { get; set; }
    string Nazwa { get; set; }
  }
}