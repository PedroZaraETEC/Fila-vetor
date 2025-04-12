using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeClienstesVetor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cliente cliente = new Cliente();
            cliente.cadastrar();
            cliente.organizarLista();
            cliente.inserirCliente();
            cliente.inserirCliente();
            cliente.inserirCliente();
            cliente.exibirListaSimples();


        }
    }
}
