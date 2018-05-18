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

            var estadias = DbFactory.Instance.EstadiaRepository.BuscarAtivas();

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
            var estadiaAux = DbFactory.Instance.EstadiaRepository.BuscarAtivaPelaPlaca(estadia.veiculo.Placa);

            if (estadiaAux == null)
            {

                var tipo = DbFactory.Instance.TipoVeiculoRepository.FindFirstById(idTipoVeiculo);
                estadia.DtEntrada = DateTime.Now;
                estadia.veiculo.Tipo = tipo;

                DbFactory.Instance.EstadiaRepository.Save(estadia);

                var estadias = DbFactory.Instance.EstadiaRepository.BuscarAtivas();

                return PartialView("_TblEstadias", estadias);
            }
            else
            {
                throw new Exception("Veículo já estacionado");
            }
        }

        public PartialViewResult SairEstadia(String placa, Boolean info)
        {
            var estadia = DbFactory.Instance.EstadiaRepository.BuscarAtivaPelaPlaca(placa);

            if (estadia != null)
            {
                estadia.DtSaida = DateTime.Now;
                var difData = (estadia.DtSaida - estadia.DtEntrada);
                var valor = 0.0;

                if (difData.Hours >= 0 || difData.Minutes > 15)
                {
                    valor = estadia.veiculo.Tipo.ValorHora * (difData.Hours + 1);
                }
                estadia.TotalAPagar = valor;

                ViewBag.Info = info;

                return PartialView("_InfoSaidaEstadia", estadia);
            }
            else
            {
                throw new Exception("Estadia não encontrada");
            }
        }

        public PartialViewResult BaixarEstadia(Estadia estadia)
        {
            var estadiaAux = DbFactory.Instance.EstadiaRepository.FindFirstById(estadia.Id);
            estadiaAux.DtSaida = estadia.DtSaida;
            estadiaAux.TotalAPagar = estadia.TotalAPagar;

            DbFactory.Instance.EstadiaRepository.Update(estadiaAux);

            var estadias = DbFactory.Instance.EstadiaRepository.BuscarAtivas();
            return PartialView("_TblEstadias", estadias);
        }
    }
}