using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MLM.DataAccess;
using MLM.Models;
namespace MLM.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index(Usuario F)
        {
            var u = (Usuario)Session["UsrLogado"];
            if (u == null)
                return RedirectToAction("Carro", "Usuario");
            u = new UsuarioDAO().Mostrar(u.Id);
            if (u == null)
                return RedirectToAction("Carro", "Usuario");
            return View(u);
        }

        public ActionResult Carro(Usuario F)
        {
            ViewBag.Modelo = new ModeloDAO().BuscarTodos();
            ViewBag.Motor = new MotorDAO().BuscarTodos();
            ViewBag.Interior = new InteriorDAO().BuscarTodos();
            ViewBag.Cor = new CorDAO().BuscarTodos();
            return View();

        }
        public ActionResult Carro_Salvar(Usuario F)
        {
            F= (Usuario)Session["UsrLogado"];
            new UsuarioDAO().Inserir_Carro(F);
            return RedirectToAction("Index", "Usuario");

        }
        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Salvar_Usuario(Usuario obj)
        {
            new UsuarioDAO().Inserir(obj);

            return RedirectToAction("Logar", "Usuario");
        }

        public ActionResult Logar_Usuario(Usuario obj)
        {
            var u = new UsuarioDAO().Logar_U(obj);
            Session["UsrLogado"] = u;
            return RedirectToAction("Carro", "Usuario");
        }

        public ActionResult Logar(Usuario obj)
        {
            return View();
        }

    }
}