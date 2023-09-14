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

        public ActionResult ActualizarResenia(LibreriaBD.RESENIAS resenia)
        {
            LIBRERIAEntities ContextoBD = new LIBRERIAEntities();
            if (ModelState.IsValid)
            {
                try
                {
                    //actualizar con entityframework
                    ContextoBD.Entry(resenia).State = System.Data.Entity.EntityState.Modified;
                    ContextoBD.SaveChanges();
                    return RedirectToAction("Resenia", "Libreria");
                }
                catch (Exception ex1)
                {
                    // Manejar errores de actualización, si es necesario
                    ModelState.AddModelError("", "Error al actualizar la reseña: " + ex1.Message);
                }
            }
            Console.WriteLine(resenia);
            return View("EditarResenia",resenia);
        }

        // GET: Libreria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Libreria/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Libreria/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Libreria/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Libreria/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Libreria/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
