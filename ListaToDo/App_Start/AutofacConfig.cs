using Autofac;
using Autofac.Integration.Mvc;
using Repozytorium.IRepo;
using Repozytorium.Models;
using Repozytorium.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ListaToDo.App_Start
{
  public static class AutofacConfig
  {
    public static void ConfigureContainer()
    {
      var builder = new ContainerBuilder();

      // Register your MVC controllers. (MvcApplication is the name of the class in Global.asax.)
      builder.RegisterControllers(typeof(MvcApplication).Assembly);

      //// ...or you can register individual controlllers manually.
      //builder.RegisterType<HomeController>().InstancePerRequest();

      builder.RegisterType<ToDoContext>().As<IToDoContext>();
      builder.RegisterType<ZadanieRepo>().As<IZadanieRepo>();

      ////// OPTIONAL: Register model binders that require DI.
      //builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
      //builder.RegisterModelBinderProvider();

      ////// OPTIONAL: Register web abstractions like HttpContextBase.
      //builder.RegisterModule<AutofacWebTypesModule>();

      ////// OPTIONAL: Enable property injection in view pages.
      //builder.RegisterSource(new ViewRegistrationSource());

      ////// OPTIONAL: Enable property injection into action filters.
      //builder.RegisterFilterProvider();

      ////// OPTIONAL: Enable action method parameter injection (RARE).
      ////builder.InjectActionInvoker();

      // Set the dependency resolver to be Autofac.
      var container = builder.Build();
      DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
    }
  }
}