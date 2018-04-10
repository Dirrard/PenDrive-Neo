using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MLM.DataAccess;
using MLM.Models;
namespace MLM.Controllers
{
    public class ModeloController : Controller
    {
        // GET: Modelo
        public ActionResult Index()
        {
            var lst = new ModeloDAO().BuscarTodos();

            return View(lst);
        }

        public ActionResult Cadastro()
        {
            return View();
        }
        public ActionResult Salvar(Modelo obj)
        {
            new ModeloDAO().Inserir(obj);

            return RedirectToAction("Index", "Modelo");
        }
    }
}
