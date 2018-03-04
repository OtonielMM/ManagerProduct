﻿//Otoniel ra 533084
// Fábio ra 558249
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Models;

namespace ProductManager.Controllers
{
    public class ProdutoController : Controller
    {

        static List<Produto> listaDeProdutos = new List<Produto> // criando uma lista estática
        {
            new Produto{Id = 1, Nome = "Tomato Soup", Categoria="Groceries",Preco = 1},
            new Produto{Id = 2, Nome = "YO-Yo", Categoria = "Toys", Preco = 3.78M},
            new Produto{Id = 3, Nome = "Hammer", Categoria = "Hardware", Preco = 16.99M},
            new Produto{Id = 4, Nome = "Orange", Categoria="Fruit",Preco = 2},
            new Produto{Id = 1, Nome = "Notebook", Categoria="Hardware",Preco = 2999.50M}
        };



        // GET: Produto
        public ActionResult Index()
        {
            return View(listaDeProdutos);
        }

        // GET: Produto/Details/5
        public ActionResult Details(int? id)
        {
            var produto = listaDeProdutos.FirstOrDefault(x => x.Id == id);
            return View(produto);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produto produto)
        {
            try
            {
                // TODO: Add insert logic here
                listaDeProdutos.Add(produto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            return View();
        }

        // POST: Produto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind ("Id, Nome, Categoria, Preco")]Produto produto)
        {
            try
            {
                // TODO: Add update logic here
                if(id != produto.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    //Atualizar  produto encontrado na lista
                    var produtoTemp = listaDeProdutos.FirstOrDefault(c => c.Id == id);
                    if (produtoTemp != null)
                    {
                        produtoTemp.Nome = produto.Nome;
                        produtoTemp.Categoria = produto.Categoria;                        
                        produtoTemp.Preco = produto.Preco;
                  
                    }
                }
                    return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                // TODO: Add delete logic here
                var produto = listaDeProdutos.FirstOrDefault(p => p.Id == id);
                listaDeProdutos.Remove(produto);
                return RedirectToAction(nameof(Index));
                
            }
            catch
            {
                return View();
            }
        }
    }
}