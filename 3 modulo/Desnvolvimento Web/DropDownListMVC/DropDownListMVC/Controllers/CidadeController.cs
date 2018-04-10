using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using DropDownListMVC.DataAccess;

namespace DropDownListMVC.Controllers
{
    public class CidadeController : Controller
    {
        // GET: Cidade
        public ActionResult Index()
        {
            var lst = new cidadeDAO().BuscarTodos();

            return View();
        }
        public ActionResult Cadastro()
        {
            ViewBag.Estados = new EstadoDAO().BuscarTodos();
            return View();
        }
        public ActionResult Salvar(Cidade obj)
        {
            new cidadeDAO().Inserir(obj);
            return RedirectToAction("Index", "Estado");
        }
    }
}