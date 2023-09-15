using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using LibreriaBD;

namespace Libreria.Controllers
{
    public class AccesoController : Controller
    {


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(LibreriaBD.USUARIOS objUsuario)
        {
            bool registrado;
            string mensaje;
            if(objUsuario.clave == objUsuario.confirmarClave)
            {
                //se convierte la clave registrada para ser almacenada
                objUsuario.clave = ConvertirClave(objUsuario.clave);
            }
            else
            {
                //viewdata envia mensaje del controlador a la vista
                ViewData["Mensaje"] = "Las contraseñas no coinciden";
                return View();
            }

            using ( var contextoBD = new LIBRERIAEntities())
            {
                // Declarar parámetros de salida
                var registradoParam = new ObjectParameter("registrado", typeof(bool));
                var mensajeParam = new ObjectParameter("mensaje", typeof(string));

                if (ModelState.IsValid)
                {
                    contextoBD.sp_Usuarios(objUsuario.documento, objUsuario.nombreCompleto, objUsuario.email,  objUsuario.clave,registradoParam,mensajeParam);

                    // Obtener los valores de los parámetros de salida
                    registrado = (bool)registradoParam.Value;
                    mensaje = mensajeParam.Value.ToString();

                    //se envia mensaje a la vista
                    ViewData["Mensaje"] = mensaje;

                    if (registrado)
                    {
                        return RedirectToAction("Login", "Acceso");
                    }

                }
                
                    return View();
                

              
              
            }

              
        }

        public static string ConvertirClave(string texto)
        {
            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash= SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));
                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }
            return Sb.ToString();
        }

        [HttpPost]
        public ActionResult Login(LibreriaBD.USUARIOS objUsuario)
        {
            // se convierte la clave


            objUsuario.clave = ConvertirClave(objUsuario.clave);
            using (var contextoBD = new LIBRERIAEntities())
            {
                if (ModelState.IsValid)
                {
                    int resultado = Convert.ToInt32(contextoBD.sp_ValidarUsuarios(objUsuario.email, objUsuario.clave).FirstOrDefault());
                    objUsuario.id = resultado;



                }
            }
                if (objUsuario.id != 0)
                {
                objUsuario.clave = ConvertirClave(objUsuario.clave);

                //crear sesion
                    Session["usuario"] = objUsuario;
                    return RedirectToAction("Inicio", "Libreria");
                }
                else
                {
                    // Usuario no encontrado, muestra el mensaje
                    ViewData["Mensaje"] = "Usuario no encontrado";
                    return View();
                }

            
           
           
        }

       

    }
}