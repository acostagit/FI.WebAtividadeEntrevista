using FI.AtividadeEntrevista.DML;
using FI.AtividadeEntrevista.InterfaceGenerica;
using System;
using System.Collections.Generic;

namespace FI.AtividadeEntrevista.BLL
{
    public class BoBeneficiario : ICadastroGenerico<DML.Beneficiario>
    {
        public void Alterar(Beneficiario beneficiario)
        {
            DAL.DaoBeneficiario cli = new DAL.DaoBeneficiario();
            cli.Alterar(beneficiario);
        }

        public Beneficiario Consultar(long id)
        {
            DAL.DaoBeneficiario beneficiario = new DAL.DaoBeneficiario();
            return beneficiario.Consultar(id);
        }

        public void Excluir(long id)
        {
            DAL.DaoBeneficiario beneficiario = new DAL.DaoBeneficiario();
            beneficiario.Excluir(id); throw new NotImplementedException();
        }

        public long Incluir(Beneficiario entidade)
        {
            DAL.DaoBeneficiario beneficiario = new DAL.DaoBeneficiario();
            return beneficiario.Incluir(entidade);
        }

        public List<Beneficiario> Listar()
        {
            DAL.DaoBeneficiario beneficiario = new DAL.DaoBeneficiario();
            return beneficiario.Listar();
        }

        public bool VerificarCPF(string cpf)
        {
            DAL.DaoBeneficiario beneficiario = new DAL.DaoBeneficiario();
            return beneficiario.VerificarCPF(cpf);
        }

    }
}
