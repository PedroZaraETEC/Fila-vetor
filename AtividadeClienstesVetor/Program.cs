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
            string escolhaUser = "i";

            Console.WriteLine("\t\t--Menu Principal--");
            Console.WriteLine("\nBem vindo, aqui é o seu menu principal,\ndentro deste programa temos diversas \nopções e atividades para o seu gerenciamento");


            while (escolhaUser.ToUpper() != "Q")
            {
                Console.WriteLine("\n\nFunções disponíveis:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n1.Cadastrar Pessoas\n2.Inserir essas mesmas pessoas dentro da fila\n3.Atender os clientes na fila\n4.Exibir lista de clientes\n5.Exibir lista de clientes não listados\nQ - Sair do programa");
                Console.ResetColor();
                Console.Write("\nOque deseja fazer: ");
                escolhaUser = Console.ReadLine().ToUpper();
                    
                switch (escolhaUser)
                {
                    case "1":
                        Console.Clear();
                        cliente.cadastrar();
                    break;

                    case "2":
                        if (cliente != null)
                        {
                            int qtdpessoas;
                            Console.Write("Quantas pessoas cadastradas dejesa inserir: ");
                            qtdpessoas = int.Parse(Console.ReadLine());

                            if (qtdpessoas > 0)
                            {
                                for (int i = 0; i < qtdpessoas; i++)
                                {
                                    cliente.inserirCliente();
                                    Console.Clear();
                                }
                            }
                        }
                        
                        else
                        {
                            Console.WriteLine("Não há clientes para inserir");
                        }
                    break;

                    case "3":
                        if (cliente != null)
                        {
                            int qtdpessoas;
                            Console.Write("Quantas pessoas cadastradas dejesa atender: ");
                            qtdpessoas = int.Parse(Console.ReadLine());

                            if (qtdpessoas > 0)
                            {
                                for (int i = 0; i < qtdpessoas; i++)
                                {
                                    cliente.atender();
                                }
                            }
                        }

                        else
                        {
                            Console.WriteLine("Não há clientes para atender");
                        }
                        break;

                    case "4":
                        if (cliente != null)
                        {
                            cliente.exibirListaSimples();
                            Console.ReadKey();
                            Console.Clear();
                        }
                    break;

                    case "5":
                        if (cliente != null)
                        {
                            cliente.exibirListaClientesNaoListados();
                            Console.ReadKey();
                            Console.Clear();
                        }
                    break;

                    case "Q":
                        Console.Clear();
                    break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nERROR: Número ou caractere inválidos");
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                    break;
                }

            }
        }
    }
}
