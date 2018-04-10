using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MLM.DataAccess;
using MLM.Models;
namespace MLM.Controllers
{
    public class CorController : Controller
    {
        // GET: Cor
        public ActionResult Index()
        {
            var lst = new CorDAO().BuscarTodos();

            return View(lst);
        }

        public ActionResult Cadastro()
        {
            return View();
        }
        public ActionResult Salvar(Cor obj)
        {
            new CorDAO().Inserir(obj);

            return RedirectToAction("Index", "Cor");
        }
    }
}