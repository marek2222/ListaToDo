using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MyTodo_Service
{
  

  [DataContract(Namespace = "http://marek2222.com/Zadania")]
  public class Zadania
  {
    [DataMember(Order = 1)]
    public DataTable Tabela { get; set; }
  }
}