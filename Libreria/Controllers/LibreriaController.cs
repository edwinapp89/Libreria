using LibreriaBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Libreria.Controllers
{
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
                if(eliminarR == null)
                {
                    return View();
                }
                contexto.RESENIAS.Remove(eliminarR);
                contexto.SaveChanges();
                return RedirectToAction("Resenia","Libreria");
            }
              
        }

       
    }
}
