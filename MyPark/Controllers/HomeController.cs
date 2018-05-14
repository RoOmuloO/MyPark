using MyPark.Model.DataBase;
using MyPark.Model.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPark.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var users = DbFactory.Instance.UserRepository.FindAll();

            if(users.Count <= 0)
            {
                
                var operador = new Operador()
                {
                    DtAdmissao = DateTime.Now,
                    Inativo = false,
                    Nome = "Administrador",
                    Usuario = new User()
                    {
                        Login = "admin",
                        Senha = "aDmIn"

                    }
            };

                DbFactory.Instance.OperadorRepository.Save(operador);
                
            }

            var estadias = DbFactory.Instance.EstadiaRepository.FindAll();

            return View(estadias);
        }

        public PartialViewResult NovaEntrada()
        {
            var tipos = DbFactory.Instance.TipoVeiculoRepository.FindAll();

            ViewBag.Tipos = new SelectList(tipos, "Id", "Titulo");

            return PartialView("_NovaEstadia", new Estadia());
        }

        public PartialViewResult CriarEstadia(Estadia estadia, Guid idTipoVeiculo)
        {
            var tipo = DbFactory.Instance.TipoVeiculoRepository.FindFirstById(idTipoVeiculo);
            estadia.DtEntrada = DateTime.Now;
            estadia.veiculo.Tipo = tipo;

            DbFactory.Instance.EstadiaRepository.Save(estadia);

            var estadias = DbFactory.Instance.EstadiaRepository.FindAll();

            return PartialView("_TblEstadias", estadias);
        }
    }
}