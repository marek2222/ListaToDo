using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MyTodo_Service
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
  // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
  public class ZadaniaService : IZadaniaService
  {

    public Zadania PobierzZadania()
    {
      string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

      Zadania zadania = new Zadania();
      using (SqlConnection con = new SqlConnection(cs))
      {
        string query = "SELECT [Id],[Nazwa],[Opis],[Termin],[Status] FROM [ListaToDo].[dbo].[Zadanie]";
        SqlCommand cmd = new SqlCommand(query, con);
        
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable("zadania");
        da.Fill(dt);
        zadania.Tabela = dt;
      }
      return zadania;
    }
  }
}
