using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyTodo_Client
{
  public partial class WebForm1 : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      ServiceReference1.ZadaniaServiceClient klient = new ServiceReference1.ZadaniaServiceClient();
      ServiceReference1.Zadania zadania = new ServiceReference1.Zadania();
      zadania = klient.PobierzZadania();
      DataTable dt = new DataTable();
      dt = zadania.Tabela;
      GridView1.DataSource = dt.DefaultView;
      GridView1.DataBind();
    }
  }
}