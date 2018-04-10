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
    public class EstadoController : Controller
    {
        // GET: Estado
        public ActionResult Index()
        {
            var lst = new EstadoDAO().BuscarTodos();

            return View(lst);
        }
        public ActionResult Cadastro()
        {
            return View();
        }
        public ActionResult Salvar(Estado obj)
        {
            new EstadoDAO().Inserir(obj);
            return RedirectToAction("Index", "Estado");
        }
    }
}