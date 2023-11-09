using Restaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurante.Controllers
{
    public class PratosController : Controller
    {
        // GET: Pratos
        public ActionResult Index()
        {
            Cardapio a = new Cardapio();
            return View(a);

        }
        

        public ActionResult CadastroPratos()
        {
            try
            {
                DBRestaurante banco = new DBRestaurante();

                Models.Restaurante restaurante = new Models.Restaurante();

                return View(restaurante.Lista());
            }catch(InvalidCastException e)
            {
                ViewBag.error = "Erro ao exibir lista de restaurantes" + e.Message;
                return View();
            }
        }


        public string CadastroPra(int rest, string nomePrato, string valorPrato)
        {
            try
            {
                DBRestaurante banco = new DBRestaurante();
                Cardapio prato = new Cardapio();
                Models.Restaurante restaurante = new Models.Restaurante();

                prato.nomePrato = nomePrato;
                prato.Restaurante = restaurante.Lista().Where(x => x.RestauranteId == rest).FirstOrDefault();
                prato.valorPrato = float.Parse(valorPrato);
                banco.Cardapio.Add(prato);
                banco.SaveChanges();
                Response.Redirect("~/Pratos/Index");
                return "Salvo com sucesso";
            }catch(InvalidCastException e)
            {
                return "Erro ao salvar: " + e.Message;
            }
        }
        [HttpGet]
        public void Excluir(int id, int redirect = 1)
        {
            try
            {
                Cardapio prato = new Cardapio();
                DBRestaurante banco = new DBRestaurante();

                Cardapio cardapioExcluir = banco.Cardapio.Where(x => x.CardapioId == id).First();
                banco.Set<Cardapio>().Remove(cardapioExcluir);
                banco.SaveChanges();
                if (redirect == 1)
                {
                    Response.Redirect("~/Pratos/Index");
                }
            }catch(InvalidCastException e)
            {
                ViewBag.error = "Erro ao excluir: " + e.Message;
            }
        }
        [HttpGet]
        public ActionResult Editar(int id, int rest)
        {
            try
            {
                Cardapio prato = new Cardapio();
                DBRestaurante banco = new DBRestaurante();
                Models.Restaurante restaurantes = new Models.Restaurante();
                
                Cardapio cardapioAlterar = banco.Cardapio.Where(x => x.CardapioId == id).First();
                

                ViewBag.restaurantes = restaurantes.Lista();

                ViewBag.idRestaurante = rest;

                return View(cardapioAlterar);
            }catch(InvalidCastException e)
            {
                ViewBag.error = "Erro ao tentar editar: " + e.Message;
                return View();
            }
        }
        [HttpGet]
        public void Alterar(int id, string nomePrato, int rest , string valorPrato)
        {
            try
            {
                Cardapio prato = new Cardapio();
                DBRestaurante banco = new DBRestaurante();
                Models.Restaurante restaurante = new Models.Restaurante();

                Cardapio cardapioAlterar = banco.Cardapio.Where(x => x.CardapioId == id).First();
                cardapioAlterar.nomePrato = nomePrato;
                cardapioAlterar.valorPrato = float.Parse(valorPrato);
                cardapioAlterar.CardapioId = id;
                cardapioAlterar.Restaurante = restaurante.Lista().Where(x => x.RestauranteId == rest).FirstOrDefault();
                banco.SaveChanges();
                Response.Redirect("~/Pratos/Index");
            }catch(InvalidCastException e)
            {
                ViewBag.error = "Erro ao alterar: " + e.Message;
            }
        }

    }
}