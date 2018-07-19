using AutoMapper;
using Repozytorium.Models;
using Repozytorium.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ListaToDo.Controllers
{
  public class ZadanieViewModelController : Controller
  {
    private ToDoContext db = new ToDoContext();

    //private MapperConfiguration config;
    public ZadanieViewModelController() //MapperConfiguration config)
    {
      ////this.config = config;
      //config = new MapperConfiguration(cfg => {
      //  cfg.CreateMap<Zadanie, ZadanieViewModel>();
      //});
      Mapper.Initialize(cfg => cfg.CreateMap<Zadanie, ZadanieViewModel>());
    }

    // GET: ZadanieViewModel
    public ActionResult Index()
    {
      //Mapper.Initialize(cfg => cfg.CreateMap<Zadanie, ZadanieViewModel>());

      var query = db.Zadania.ToArray();
      IEnumerable<ZadanieViewModel> dest = Mapper.Map<Zadanie[], IEnumerable<ZadanieViewModel>>(query);
      return View(dest);

      //var query = db.Zadania.ToArray();
      //IEnumerable<ZadanieViewModel> ienumerableDest = Mapper.Map<Zadanie[], IEnumerable<ZadanieViewModel>>(query);
      //return View(ienumerableDest);

      //var query = db.Zadania.ToArray();
      //IEnumerable<ZadanieViewModel> ienumerableDest = Mapper.Map<Zadanie[], IEnumerable<ZadanieViewModel>>(query);
      //return View(ienumerableDest);

      //var query = db.Zadania.ToArray();
      //ICollection<ZadanieViewModel> icollectionDest = Mapper.Map<Zadanie[], ICollection<ZadanieViewModel>>(query);
      //return View(icollectionDest);

      //var query = db.Zadania.ToArray();
      //IList<ZadanieViewModel> ilistDest = Mapper.Map<Zadanie[], IList<ZadanieViewModel>>(query);
      //return View(ilistDest);

      //var query = db.Zadania.ToArray();
      //List<ZadanieViewModel> listDest = Mapper.Map<Zadanie[], List<ZadanieViewModel>>(query);
      //return View(listDest);

      //var query = db.Zadania.ToArray();
      //ZadanieViewModel[] arrayDest = Mapper.Map<Zadanie[], ZadanieViewModel[]>(query);
      //return View(arrayDest);
    }


    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}
