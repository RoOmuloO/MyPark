using MyPark.Model.DataBase;
using MyPark.Model.DataBase.Models;
using System.Web.Mvc;

namespace MyPark.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult TipoVeiculo()
        {
            var TipoVeiculos = DbFactory.Instance.TipoVeiculoRepository.FindAll();
            return View(TipoVeiculos);
        }

        public ActionResult AddTipoVeiculo()
        {
            return View(new TipoVeiculo());
        }

        public PartialViewResult GravarTipoVeiculo(TipoVeiculo tipoVeiculo)
        {
            

            DbFactory.Instance.TipoVeiculoRepository.SaveOrUpdate(tipoVeiculo);

            var TipoVeiculos = DbFactory.Instance.TipoVeiculoRepository.FindAll();

            return PartialView("_TabelaTipoVeiculoView", TipoVeiculos);
        }

        public ActionResult EditarTipoVeiculo (TipoVeiculo tipoVeiculo)
        {
            DbFactory.Instance.TipoVeiculoRepository.SaveOrUpdate(tipoVeiculo);

            return RedirectToAction("TipoVeiculo");
        }

        public PartialViewResult ExibirAddTipoVeiculo()
        {
            return PartialView("_AddTipoVeiculo", new TipoVeiculo());
        }

        public ActionResult Planos()
        {
            var Planos = DbFactory.Instance.PlanoRepository.FindAll();
            return View(Planos);
        }

        public PartialViewResult ExibirAddPlanos()
        {
            return PartialView("_AddPlano", new Plano());
        }

        public PartialViewResult GravarPlano(Plano plano)
        {
            

            DbFactory.Instance.PlanoRepository.SaveOrUpdate(plano);

            var Planos = DbFactory.Instance.PlanoRepository.FindAll();

            return PartialView("_TabelaAddPlanoView", Planos);
        }
    }
}