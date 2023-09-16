using Libreria.Permisos;
using LibreriaBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Libreria.Controllers
{
    // se agrega referencia a permisos apra que permita el acceso si se inicia sesion
    //antes de que se ejecute algun controlador que valide la sesion
    [ValidarSesion]
    public class LibreriaController : Controller
    {
        // GET: Libreria
        public ActionResult Inicio()
        {
            List<LibreriaBD.LIBROS> ListaLibros;
            using (var ContextoBD = new LIBRERIAEntities())
            {
                ListaLibros = ContextoBD.LIBROS.ToList();   
            }
                return View(ListaLibros);

        }

        public ActionResult Resenia()
        {
            List<LibreriaBD.RESENIAS> ListaResenias;
            using (var ContextoBD = new LIBRERIAEntities())
            {
                ListaResenias = ContextoBD.RESENIAS.ToList();
            }
            return View(ListaResenias);
        }

        [HttpGet]
        public ActionResult CrearResenia()
        {
            return View();
        }
        [HttpPost]
        //OBJETO QUE SE RECIBE DIFERENTE A LOS VALORES
        public ActionResult CrearResenia(LibreriaBD.RESENIAS objResenia)
        {
            using (var contextoBD = new LIBRERIAEntities())
            {
                if (ModelState.IsValid)
                {
                    contextoBD.sp_Resenias(objResenia.resenia, objResenia.comentario, objResenia.calificacion, objResenia.idLibro, objResenia.idUsuario);
                    return RedirectToAction("Resenia", "Libreria");
                }
            }
            return View();
        }
       public ActionResult EditarResenia(int id)
        {
            LIBRERIAEntities ContextoBD = new LIBRERIAEntities();
            var resenia = ContextoBD.RESENIAS.FirstOrDefault(p => p.id == id);
            if(resenia == null)
            {
                return View();
            }
            return View(resenia);
        }

        //los parametros no deben tener el mismo nombre del modelo
        public ActionResult ActualizarResenia( LibreriaBD.RESENIAS objResenia)
        {
            using (var contexto = new LIBRERIAEntities())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        //actualizar con entityframework
                        contexto.Entry(objResenia).State = System.Data.Entity.EntityState.Modified;
                        contexto.SaveChanges();
                        return RedirectToAction("Resenia", "Libreria");
                    }
                    catch (Exception ex)
                    {
                        // Manejar errores de actualización, si es necesario
                        ModelState.AddModelError("", "Error al actualizar la reseña: " + ex.Message);
                    }
                }
            }
           
            return View("EditarResenia", objResenia);
        }


        public ActionResult EliminarResenia(int id)
        {
            using (var contexto = new LIBRERIAEntities())
            {
                var eliminarR = contexto.RESENIAS.FirstOrDefault(p => p.id == id);
                if (eliminarR == null)
                {
                    return View();
                }
                contexto.RESENIAS.Remove(eliminarR);
                contexto.SaveChanges();
                return RedirectToAction("Resenia", "Libreria");
            }

        }
            public ActionResult CerrarSesion()
            {
                Session["usuario"] = null;
                return RedirectToAction("Login","Acceso");
            }


       
    }
}
