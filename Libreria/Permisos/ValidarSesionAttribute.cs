using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Libreria.Permisos
{
    //se referencia clase ActionFilterAttribute permite ejecutar una accion
    //antes o despues que la ejecute el controlador, en este caso se usa para
    //verifica la validedez de la sesion de usuario
    public class ValidarSesionAttribute: ActionFilterAttribute
    {
        //este metodo proporciona informacion de la accion a ejecutar y su contexto.
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //proceso para evitar que se pueda acceder sin iniciar sesion
            if (HttpContext.Current.Session["usuario"]==null)
            {
                //si no existe la sesion que redirija a login
                filterContext.Result = new RedirectResult("~/Acceso/login");
            }
           
            //permite que la clase realice cualquier accion
            base.OnActionExecuting(filterContext);
        }
    }
}