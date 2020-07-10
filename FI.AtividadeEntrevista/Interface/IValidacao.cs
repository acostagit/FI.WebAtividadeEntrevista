using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI.AtividadeEntrevista.Interface
{
    public interface IValidacao
    {
        //valida CPFl
        bool ValidarCPF(string cpf);

        bool ValidarCNPJ(string cnpj);
    }
}
