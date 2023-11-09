using Restaurante.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurante.Controllers
{
    public class RestaurantesController : Controller
    {
        // GET: Restaurantes
        public ActionResult Index()
        {
            Models.Restaurante a = new Models.Restaurante();
            //var listaDePratos = a.Lista();
            return View(a);
        }
        public ActionResult CadastroRestaurante()
        {
            DBRestaurante banco = new DBRestaurante();
           Models.Restaurante rest = new Models.Restaurante();

            //rest.NomeRestaurante = "Testes Bar";

            //banco.Restaurante.Add(rest);
            //banco.SaveChanges();

            //IEnumerable<Models.Restaurante> listaRestaurantes = banco.Restaurante.ToList();

            //ViewBag.idRestaurante = listaRestaurantes.First().RestauranteId;
            //ViewBag.nomeRestaurante = listaRestaurantes.First().NomeRestaurante;

            return View();
        }

        [HttpPost]
        public ActionResult CadastroRest(string nomeRestaurante)
        {
            try
            {
                DBRestaurante banco = new DBRestaurante();
                Restaurante.Models.Restaurante rest = new Restaurante.Models.Restaurante();

                rest.NomeRestaurante = nomeRestaurante;

                banco.Restaurante.Add(rest);
                banco.SaveChanges();
                ViewData["mensagem"] = "Cadastro realizado com sucesso!";
                Response.Redirect("~/Restaurantes/Index");
                return View();
            }
            catch(InvalidCastException e)
            {
                ViewData["mensagem"] = "Ocorreu um erro ao cadastrar: "+ e.Message;
                return View();
            }
            
        }

        public IEnumerable<Restaurante.Models.Restaurante> Lista()
        {
        
            DBRestaurante banco = new DBRestaurante();
            Models.Restaurante restaurante = new Models.Restaurante();

            IEnumerable<Models.Restaurante> listaRestaurante = banco.Restaurante.ToList();
            return listaRestaurante;
        }

        [HttpGet]
        public ActionResult Search(string search)
        {
            Models.Restaurante a = new Models.Restaurante();
            ViewBag.search = search;
            return View(a.Lista().Where(x=>x.NomeRestaurante == search));
         
        }
        [HttpGet]
        public void Excluir(int id)
        {
            try
            {
                Models.Restaurante restaurante = new Models.Restaurante();
                DBRestaurante banco = new DBRestaurante();
                Cardapio cardapio = new Cardapio();
                PratosController c = new PratosController();
                
                var pratosRelacionados = cardapio.Lista().Where(x=> x.Restaurante.RestauranteId == id);
                

                    foreach (var prato in pratosRelacionados.ToList())
                    {
                        c.Excluir(prato.CardapioId, 0);
                    }
              

                Models.Restaurante restauranteExcluir = banco.Restaurante.Where(x => x.RestauranteId == id).First();
                banco.Set<Models.Restaurante>().Remove(restauranteExcluir);
                banco.SaveChanges();
                Response.Redirect("~/Restaurantes/Index");
            }catch(InvalidCastException e)
            {
                ViewBag.error = "Erro ao excluir: " + e.Message;
            }
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            try
            {
                Models.Restaurante restaurante = new Models.Restaurante();
                DBRestaurante banco = new DBRestaurante();

                Models.Restaurante restauranteAlterar = banco.Restaurante.Where(x => x.RestauranteId == id).First();


                return View(restauranteAlterar);
            }catch(InvalidCastException e)
            {
                ViewBag.error = "Erro ao tentar editar: " + e.Message;
                return View();
            }
        }
        [HttpGet]
        public void Alterar(int id, string nomeRestaurante)
        {
            try
            {
                Models.Restaurante restaurante = new Models.Restaurante();
                DBRestaurante banco = new DBRestaurante();

                Models.Restaurante restauranteAlterar = banco.Restaurante.Where(x => x.RestauranteId == id).First();
                restauranteAlterar.NomeRestaurante = nomeRestaurante;
                restauranteAlterar.RestauranteId = id;
                banco.SaveChanges();
                Response.Redirect("~/Restaurantes/Index");
            }catch(InvalidCastException e)
            {
                ViewBag.error = "Erro ao alterar: " + e.Message;
            }
        }
    }
}