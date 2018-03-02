//Otoniel ra 533084
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Models;

namespace ProductManager.Controllers
{
    public class UsuarioController : Controller
    {

        static List<Usuario> listaDeUsuarios = new List<Usuario> // criando uma lista estática
        {
            new Usuario{Id = 1, Nome = "Otoniel", Cpf="12345",Email = "estudantedaniel@homtail.com"},
            new Usuario{Id = 2, Nome = "Gabriel", Cpf = "456789", Email = "estudantedaniel@homtail.com"},
            new Usuario{Id = 3, Nome = "TIO", Cpf = "789456", Email = "estudantedaniel@homtail.com"}
        };


        // GET: Usuario
        public ActionResult Index()
        {
            return View(listaDeUsuarios);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int? id)
        {
            var usuario = listaDeUsuarios.FirstOrDefault(x => x.Id == id);
            return View();
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                // TODO: Add insert logic here
                listaDeUsuarios.Add(usuario);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            return View();
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,[Bind("Id, Nome, Cpf, Email")]Usuario usuario)
        {
            try
            {
                // TODO: Add update logic here
                if (id != usuario.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    //Atualizar  usuario encontrado na lista
                    var usuarioTemp = listaDeUsuarios.FirstOrDefault(c => c.Id == id);
                    if (usuarioTemp != null)
                    {
                        usuarioTemp.Nome = usuario.Nome;
                        usuarioTemp.Cpf = usuario.Cpf;
                        usuarioTemp.Email = usuario.Email;

                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                // TODO: Add delete logic here
                var usuario = listaDeUsuarios.FirstOrDefault(m => m.Id == id);
                listaDeUsuarios.Remove(usuario);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}