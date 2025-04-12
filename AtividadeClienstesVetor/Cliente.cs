using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeClienstesVetor
{
    internal class Cliente : Pessoa
    {
        Pessoa[] pessoasNaoListadas = new Pessoa[11];
        Pessoa[] clientes = new Pessoa[11];

        /*public override void cadastrar()
        {
            Console.WriteLine("Possui quantos clientes: ");
            int quantidadeClientes = int.Parse(Console.ReadLine());

            for (int clientesPassados = 0; clientesPassados < quantidadeClientes; clientesPassados++)
            {
                clientes[clientesPassados] = new Pessoa();
                clientes[clientesPassados].cadastrar();
            }
        }*/


        public override void cadastrar()
        {
            Console.WriteLine("\t\tÁrea de cadastro do cliente\n");
            Console.Write("Quantas pessoas deseja cadastrar (MAX: 10): ");
            int numPessoasCadastrar = int.Parse(Console.ReadLine());

            for (int procuraIndiceVazio = 0; procuraIndiceVazio < numPessoasCadastrar; procuraIndiceVazio++)
            {
                if (pessoasNaoListadas[procuraIndiceVazio] == null)
                {
                    Console.WriteLine($"Pessoa {procuraIndiceVazio + 1}");
                    pessoasNaoListadas[procuraIndiceVazio] = new Pessoa();
                    pessoasNaoListadas[procuraIndiceVazio].cadastrar();
                    Console.Clear();
                }
            }
        }


        public void inserirCliente()
        {
            Console.WriteLine("\nQual cliente devemos inserir a lista: \n");
            exibirListaClientesNaoListados();
            Console.Write("Escreva: ");
            string nomeEscolhido = Console.ReadLine();
            procurar(nomeEscolhido, true);

            Console.WriteLine("\nPessoa inserida a lista com sucesso");
            Console.ReadKey();
            Console.Clear();
        }


        public void atender()
        {
            Console.Write("Qual cliente deseja: ");
            string nomeEscolhido = Console.ReadLine();
            procurar(nomeEscolhido, false);

            Console.WriteLine("\nCliente atendido");
            Console.ReadKey();
            Console.Clear();
        }


        public void procurar(string nomeEscolhido, bool adicionar)
        {
            if (adicionar)
            {
                for (int buscaNome = 0; buscaNome < pessoasNaoListadas.Length; buscaNome++)
                {
                    if (pessoasNaoListadas[buscaNome] != null && pessoasNaoListadas[buscaNome].nome == nomeEscolhido)
                    {
                        for (int buscaIndiceVazio = 0; buscaIndiceVazio < clientes.Length; buscaIndiceVazio++)
                        {
                            if (clientes[buscaIndiceVazio] == null)
                            {
                                clientes[buscaIndiceVazio] = pessoasNaoListadas[buscaNome];
                                pessoasNaoListadas[buscaNome] = null;
                                break;
                            }
                        }
                        break;
                    }
                }
                organizarLista();
            }

            else
            {
                for (int buscaIndice = 0; buscaIndice < clientes.Length; buscaIndice++)
                {
                    if (clientes[buscaIndice].nome == nomeEscolhido)
                    {
                        clientes[buscaIndice] = null;
                        break;
                    }
                }
                organizarLista();
            }
        }


        /*public void organizarLista()
        {
            for (int posicaoCliente = 0; posicaoCliente < clientes.Length; posicaoCliente++)
            {
                Pessoa clienteAtual = clientes[posicaoCliente];
                Pessoa clienteProximo = (posicaoCliente + 1 < clientes.Length) ? clientes[posicaoCliente + 1] : null;

                //if (clientes[posicaoCliente].prioridade == false || clientes[posicaoCliente] == null && clientes[posicaoCliente + 1].prioridade == true || clientes[posicaoCliente] == null)

                if ((clienteAtual == null && clienteProximo != null && clienteProximo.prioridade) ||
                    (clienteAtual != null && !clienteAtual.prioridade && clienteProximo != null && clienteProximo.prioridade))
                {
                    for (int clientePrioritario = 0; clientePrioritario < clientes.Length - 1; clientePrioritario++)
                    {
                        Pessoa clienteNaoPrioritario = clientes[clientePrioritario];
                        clientes[clientePrioritario] = clientes[clientePrioritario + 1];
                        clientes[clientePrioritario + 1] = clienteNaoPrioritario;
                    }
                }
            }
        }*/

        public void organizarLista()
        {
            for (int posicao = 0; posicao < clientes.Length - 1; posicao++)
            {
                for (int posicaoIndice = 0; posicaoIndice < clientes.Length - 1; posicaoIndice++)
                {
                    Pessoa atual = clientes[posicaoIndice];
                    Pessoa proximo = clientes[posicaoIndice + 1];

                    if ((atual == null && proximo != null && proximo.prioridade) ||
                        (atual != null && !atual.prioridade && proximo != null && proximo.prioridade))
                    {
                        clientes[posicaoIndice] = proximo;
                        clientes[posicaoIndice + 1] = atual;
                    }
                }
            }

            for (int posicao = 0; posicao < pessoasNaoListadas.Length - 1; posicao++)
            {
                for (int posicaoIndice = 0; posicaoIndice < pessoasNaoListadas.Length - 1; posicaoIndice++)
                {
                    Pessoa atual = pessoasNaoListadas[posicaoIndice];
                    Pessoa proximo = pessoasNaoListadas[posicaoIndice + 1];

                    if ((atual == null && proximo != null && proximo.prioridade) ||
                        (atual != null && !atual.prioridade && proximo != null && proximo.prioridade))
                    {
                        pessoasNaoListadas[posicaoIndice] = proximo;
                        pessoasNaoListadas[posicaoIndice + 1] = atual;
                    }
                }
            }
        }


        public void exibirListaAvancada()
        {
            Console.WriteLine("\t\tLista de Clientes\n");
            for(int indiceCliente = 0; indiceCliente < clientes.Length; indiceCliente++)
            {
                if (clientes[indiceCliente] != null)
                {
                    Console.WriteLine($"\nNome: {clientes[indiceCliente].nome}");
                    Console.WriteLine($"Idade: {clientes[indiceCliente].idade}");
                    Console.WriteLine($"Cpf: {clientes[indiceCliente].cpf}\n\n");
                }
            }
            Console.ReadKey();
            Console.Clear();
        }


        public void exibirListaSimples()
        {
            Console.Write("Fila Listados:\n");
            for (int indiceCliente = 0; indiceCliente < clientes.Length; indiceCliente++)
            {
                if (clientes[indiceCliente] != null)
                {
                    Console.Write($"{clientes[indiceCliente].nome} (Prioridade: {clientes[indiceCliente].prioridade})\n");
                }
            }
            //Nota: Pode-se utilizar o foreach para percorrer o vetor, igualmente com essa método que utiliza o for
        }


        public void exibirListaClientesNaoListados()
        {
            Console.Write("Fila não Listados:\n");
            for (int indiceCliente = 0; indiceCliente < pessoasNaoListadas.Length; indiceCliente++)
            {
                if (pessoasNaoListadas[indiceCliente] != null)
                {
                    Console.Write($"Nome: {pessoasNaoListadas[indiceCliente].nome} (Prioridade: {pessoasNaoListadas[indiceCliente].prioridade})\n");
                }
            }
        }


    }
}
