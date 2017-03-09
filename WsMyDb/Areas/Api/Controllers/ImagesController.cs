using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WsMyDb.Areas.Api.Models;

namespace WsMyDb.Areas.Api.Controllers
{
    public class ImagesController : Controller
    {

        DataBase database;

        public ImagesController()
        {
            database = new DataBase();
        }

        //
        // GET: /Api/Images/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult guardarClietne(Cliente item)
        {
            return Json(database.InsertarCliente(item));
        }

        [HttpGet]
        public JsonResult Clientes()
        {
            return Json(database.ObtenerClientes(),
                        JsonRequestBehavior.AllowGet);
        }
    }
}
