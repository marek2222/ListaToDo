using Repozytorium.IRepo;
using Repozytorium.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ListaToDo.Controllers
{
  public class KlientVMController : Controller
  {
    // GET: KlientVM

    private readonly IToDoContext _db;

    public KlientVMController(IToDoContext db)
    {
      _db = db;
    }

    [AcceptVerbs(HttpVerbs.Get)]
    public ActionResult Index()
    {
      //OrderDBEntities orderdb = new OrderDBEntities(); //dbcontect class
      List<KlientViewModel> KlientVMlist = new List<KlientViewModel>(); 
      // to hold list of Customer and order details
      var VMList = (from k in _db.Klienci
                          join z in _db.Zamowienia on k.KlientID equals z.KlientID
          select new { k.Nazwa, k.Komorka, k.Addres, z.DataZamowienia, z.CenaZamowienia}).ToList();
      //query getting data from database from joining two tables and storing data in VMList
      foreach (var item in VMList)
      {
        KlientViewModel vm = new KlientViewModel(); // ViewModel
        vm.Nazwa          = item.Nazwa;
        vm.Komorka        = item.Komorka;
        vm.Addres         = item.Addres;
        vm.DataZamowienia = item.DataZamowienia;
        vm.CenaZamowienia = item.CenaZamowienia;
        KlientVMlist.Add(vm);
      }
      //Using foreach loop fill data from custmerlist to List<CustomerVM>.
      return View(KlientVMlist); //List of CustomerVM (ViewModel)
    }
  }
}