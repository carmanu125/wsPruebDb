using System.Web.Mvc;

namespace WsMyDb.Areas.Api
{
    public class ApiAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Api";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Api_default",
                "Api/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "guardarClietne",
                "Api/Images/guardarClietne/{id}",
                new
                {
                    controller = "Clientes",
                    action = "Cliente",
                    id = UrlParameter.Optional
                }
            );

            context.MapRoute(
                "Clientes",
                "Api/Images/Clientes/{id}",
                new
                {
                    controller = "Images",
                    action = "Clientes",
                    id = UrlParameter.Optional
                }
            );
        }
    }
}
