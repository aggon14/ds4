using System.Web.Mvc;

namespace Semestral.Areas.EmpleadoController
{
    public class EmpleadoControllerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "EmpleadoController";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "EmpleadoController_default",
                "EmpleadoController/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}