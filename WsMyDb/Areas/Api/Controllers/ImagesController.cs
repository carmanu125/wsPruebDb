using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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

        [HttpPost]
        public JsonResult clienteImage(Cliente cliente)
        {
            String filePath = AppDomain.CurrentDomain.BaseDirectory + "/images/";
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            filePath += cliente.nameFoto;
            byte[] bytes = Convert.FromBase64String(cliente.stringFoto);
            var imageFile = new FileStream(filePath, FileMode.Create);

            imageFile.Write(bytes, 0, bytes.Length);
            imageFile.Flush();

            return Json("true");
        }
    }
}
