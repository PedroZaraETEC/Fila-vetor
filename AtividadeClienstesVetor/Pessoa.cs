using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeClienstesVetor
{
    internal class Pessoa
    {
        public string nome;
        public int idade;
        public string cpf;
        public bool prioridade;
    
        public virtual void cadastrar()
        {
            Console.Write("Digite seu nome: ");
            this.nome = Console.ReadLine();
            Console.Write("Digite sua idade: ");
            this.idade = int.Parse(Console.ReadLine());
            Console.Write("Digite seu cpf: ");
            this.cpf = Console.ReadLine();
            Console.Write("Prioridade: s/n");
            string prioridadeEscolhida = Console.ReadLine();

            if (prioridadeEscolhida.ToUpper() == "S")
            {
                this.prioridade = true;
            }
        }
    }
}
