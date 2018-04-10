using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MLM.DataAccess;
using MLM.Models;
namespace MLM.Controllers
{
    public class InteriorController : Controller
    {
        // GET: Interior
        public ActionResult Index()
        {
            var lst = new InteriorDAO().BuscarTodos();

            return View(lst);
        }

        public ActionResult Cadastro()
        {
            return View();
        }
        public ActionResult Salvar(Interior obj)
        {
            new InteriorDAO().Inserir(obj);

            return RedirectToAction("Index", "Interior");
        }
    }
}
