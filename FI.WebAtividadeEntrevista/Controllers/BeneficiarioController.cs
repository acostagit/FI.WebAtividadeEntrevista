using FI.AtividadeEntrevista.BLL;
using FI.AtividadeEntrevista.DML;
using FI.AtividadeEntrevista.Interface;
using FI.AtividadeEntrevista.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAtividadeEntrevista.Models;

namespace WebAtividadeEntrevista.Controllers
{
    public class BeneficiarioController : Controller
    {
        // GET: Beneficiario
        public ActionResult Index()
        {
            return PartialView("_CadastroBeneficiario");
            // return View();
        }

        public ActionResult PartialBeneficiario()
        {
            return PartialView();
        }

        public JsonResult Incluir(BeneficiarioModel model)
        {
            BoBeneficiario bo = new BoBeneficiario();
            var mensagemValidacao = "CPF inválido. Consulte o Admin do Sistema.";

            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                if (bo.VerificarCPF(model.CPF))
                    return Json("CPF já cadastrado no banco de dados. Admin.");

                IValidacao validador = new Validacao();
                if (!validador.ValidarCPF(model.CPF))
                    return Json(mensagemValidacao);

                model.Id = bo.Incluir(new Beneficiario()
                {
                    Nome = model.Nome,
                    CPF = model.CPF                    
                });


                return Json("Beneficiário cadastrado com sucesso.");
            }
        }

        [HttpPost]
        public JsonResult Alterar(BeneficiarioModel model)
        {
            BoBeneficiario bo = new BoBeneficiario();
            var mensagemValidacao = "CPF inválido. Consulte o Admin do Sistema.";

            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                IValidacao validador = new Validacao();
                if (!validador.ValidarCPF(model.CPF))
                    return Json(mensagemValidacao);

                bo.Alterar(new Beneficiario()
                {
                    Nome = model.Nome,
                    CPF = model.CPF,
                    IdCliente = model.IdCliente
                });

                return Json("Beneficiário alterado com sucesso");
            }
        }

        [HttpGet]
        public ActionResult Alterar(long id)
        {
            BoCliente boCliente = new BoCliente();
            BoBeneficiario beneficiarioBO = new BoBeneficiario();
            Beneficiario beneficiario = beneficiarioBO.Consultar(id);
            Cliente cliente = boCliente.Consultar(id);
            Models.BeneficiarioModel model = null;
           
            var beneficiarios = new List<Beneficiario>();
            if (beneficiario != null)
            {
                beneficiarios = beneficiarioBO.Listar().Where(b => b.IdCliente == id).ToList();
                if (beneficiarios != null)
                {
                    cliente.Beneficiarios = beneficiarios;
                }
            }

            if (cliente != null)
            {
                model = new BeneficiarioModel()
                {
                    Id = beneficiario.Id,                  
                    CPF = beneficiario.CPF,
                    IdCliente = cliente.Id
                };

                //Teste
                //var beneficiarios = new List<Beneficiario>()
                //{
                //    new Beneficiario{Id=1, CPF="12345678925", Nome="Jose Toress", IdCliente=1 },
                //    new Beneficiario{Id=2, CPF="78945612336", Nome="Maria da Silva", IdCliente=1 },
                //    new Beneficiario{Id=3, CPF="15914736987", Nome="Andreia Salves", IdCliente=1 },
                //};

                //model.Beneficiarios = beneficiarios;
            }

            return View(model);
        }
    }
}