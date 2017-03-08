using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WsMyDb.Areas.Api.Models
{
    public class Cliente
    {
        public int id { set; get; }
        public string cedula { set; get; }
        public string nombre { set; get; }
    }
}