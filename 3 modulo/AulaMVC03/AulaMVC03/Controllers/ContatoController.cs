using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using AulaMVC03.Models;
using AulaMVC03.DataAccess;

namespace AulaMVC03.Controllers
{
    public class ContatoController : Controller
    {
        public ActionResult Index()
        {
            var lstContatos = new List<Contato>();

            lstContatos = new ContatoDAO().BuscarTodos();

            return View(lstContatos);

        }
        public ActionResult Cadastro()
        {
            return View();
        }
        public ActionResult Salvar(Contato obj)
        {

            new ContatoDAO().Inserir(obj);

            return RedirectToAction("Index", "Contato");
        }
    }
}