using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI.AtividadeEntrevista.InterfaceGenerica
{
    public interface ICadastroGenerico<Entidade> where Entidade : class
    {
        long Incluir(Entidade entidade);
        void Alterar(Entidade entidade);

        Entidade Consultar(long id);

        void Excluir(long id);

        List<Entidade> Listar();
    }
}
