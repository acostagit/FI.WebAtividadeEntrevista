using FI.AtividadeEntrevista.DML;
using FI.AtividadeEntrevista.InterfaceGenerica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI.AtividadeEntrevista.DAL
{
    public class DaoBeneficiario : AcessoDados, ICadastroGenerico<DML.Beneficiario>
    {
        public void Alterar(DML.Beneficiario beneficiario)
        {
            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();

            parametros.Add(new System.Data.SqlClient.SqlParameter("Nome", beneficiario.Nome));
            parametros.Add(new System.Data.SqlClient.SqlParameter("CPF", beneficiario.CPF));
            parametros.Add(new System.Data.SqlClient.SqlParameter("Id", beneficiario.IdCliente));


            base.Executar("FI_SP_Alt_Beneficiario", parametros);
        }

        public DML.Beneficiario Consultar(long id)
        {
            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();

            parametros.Add(new System.Data.SqlClient.SqlParameter("Id", id));

            DataSet ds = base.Consultar("FI_SP_Cons_Beneficiario", parametros);
            List<DML.Beneficiario> benef = Converter(ds);

            return benef.FirstOrDefault();
        }

        public void Excluir(long id)
        {
            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();

            parametros.Add(new System.Data.SqlClient.SqlParameter("Id", id));

            base.Executar("FI_SP_Del_Beneficiario", parametros);
        }

        public long Incluir(DML.Beneficiario beneficiario)
        {
            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();

            parametros.Add(new System.Data.SqlClient.SqlParameter("Nome", beneficiario.Nome));
            parametros.Add(new System.Data.SqlClient.SqlParameter("CPF", beneficiario.CPF));
            parametros.Add(new System.Data.SqlClient.SqlParameter("IdCliente", beneficiario.IdCliente));

            DataSet ds = base.Consultar("FI_SP_Inc_BeneficiarioV2", parametros);
            long ret = 0;
            if (ds.Tables[0].Rows.Count > 0)
                long.TryParse(ds.Tables[0].Rows[0][0].ToString(), out ret);
            return ret;
        }

        public bool VerificarCPF(string CPF)
        {
            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();

            parametros.Add(new System.Data.SqlClient.SqlParameter("CPF", CPF));

            DataSet ds = base.Consultar("FI_SP_PesquisaBeneficiarioPorCPF", parametros);

            return ds.Tables[0].Rows.Count > 0;
        }

        public List<DML.Beneficiario> Listar()
        {
            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();
            var ID = 0;

            parametros.Add(new System.Data.SqlClient.SqlParameter("ID", ID));

            DataSet ds = base.Consultar("FI_SP_Cons_Beneficiario", parametros);
            List<DML.Beneficiario> cli = Converter(ds);

            return cli;
        }
        private List<DML.Beneficiario> Converter(DataSet ds)
        {
            List<DML.Beneficiario> lista = new List<DML.Beneficiario>();
            if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    DML.Beneficiario benef = new DML.Beneficiario();
                    benef.Id = row.Field<long>("Id");
                    benef.IdCliente = row.Field<long>("IdCliente");
                    benef.Nome = row.Field<string>("Nome");
                    benef.CPF = row.Field<string>("CPF");
                    lista.Add(benef);
                }
            }

            return lista;
        }
    }
}
