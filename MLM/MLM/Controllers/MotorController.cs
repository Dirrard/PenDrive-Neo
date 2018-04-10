using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MLM.DataAccess;
using MLM.Models;
namespace MLM.Controllers
{
    public class MotorController : Controller
    {
        // GET: Motor
        public ActionResult Index()
        {
            var lst = new MotorDAO().BuscarTodos();

            return View(lst);
        }

        public ActionResult Cadastro()
        {
            return View();
        }
        public ActionResult Salvar(Motor obj)
        {
            new MotorDAO().Inserir(obj);

            return RedirectToAction("Index", "Motor");
        }
    }
}
