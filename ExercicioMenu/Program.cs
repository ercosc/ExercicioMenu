using System;
using System.Collections.Generic;

namespace ExercicioMenu
{
    class Program
    {
        static List<String> nomes = new List<string>();
        static void Main(string[] args)
        {
            Menu();
        }

        private static void Menu()
        {

            TxtMenu();
            InputMenu(Console.ReadLine());



        }
        private static void TxtMenu()
        {
            Console.WriteLine("Menu Crud de nomes:");
            Console.WriteLine("1 - Adicionar novo nome:");
            Console.WriteLine("2 - Listar nomes:");
            Console.WriteLine("3 - Alterar um nome existente:");
            Console.WriteLine("4 - Deletar um nome da lista:");
            Console.WriteLine("5 - Sair:");
        }

        private static void InputMenu(string input)
        {
            switch (input)
            {
                case "1":
                    AdicionarNome();
                    TxtMenu();
                    InputMenu(Console.ReadLine());
                    break;
                case "2":
                    ListarNomes();
                    TxtMenu();
                    InputMenu(Console.ReadLine());
                    break;
                case "3":
                    AlterarNome();
                    TxtMenu();
                    InputMenu(Console.ReadLine());
                    break;
                case "4":
                    DeletarNome();
                    TxtMenu();
                    InputMenu(Console.ReadLine());
                    break;
                case "5":
                    Console.WriteLine("sair");
                    break;
                default:
                    Console.WriteLine("digite um valor válido.");
                    TxtMenu();
                    InputMenu(Console.ReadLine());
                    break;
            }
        }

        private static void AdicionarNome()
        {
            Console.WriteLine("digite o nome para adicionar:");
            string nome = Console.ReadLine();

            if (!VerificarNome(nome))
            {
                if (string.IsNullOrWhiteSpace(nome))
                {
                    Console.WriteLine("formato de nome inválido\n");
                }
                else
                {
                    nomes.Add(nome);
                    Console.WriteLine("nome adicionado com sucesso\n");
                }
            }
            else
            {
                Console.WriteLine($"O nome {nome} já existe.\n");
            }
        }

        private static void ListarNomes()
        {
            if (nomes.Count == 0)
            {
                Console.WriteLine("Insira algum nome na lista.\n");
            }
            else
            {
                for (int i = 0; i < nomes.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {nomes[i]}");
                }
                Console.WriteLine();
            }
        }

        private static void AlterarNome()
        {
            Console.WriteLine("Digite o nome que deseja alterar na lista:");
            string nomePAlterar = Console.ReadLine();
            if (nomes.Contains(nomePAlterar))
            {
                for (int i = 0; i < nomes.Count; i++)
                {
                    if (nomes[i] == nomePAlterar)
                    {
                        Console.WriteLine("novo nome:");
                            string novoNome = Console.ReadLine();
                        if(nomes.Contains(novoNome))
                        {
                            Console.WriteLine("Nome já cadastrado.\n");
                        } else
                        {
                            nomes[i] = novoNome;
                            Console.WriteLine("nome alterado com sucesso.\n");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("nome não existe.\n");
            }

        }

        private static bool VerificarNome(string nome)
        {
            foreach (string n in nomes)
            {
                if (nome == n)
                {
                    return true;
                }
            }
            return false;
        }
        private static void DeletarNome()
        {
            Console.WriteLine("digite o nome que deseja deletar:");
            string nome = Console.ReadLine();
            if (VerificarNome(nome))
            {
                for (int i = 0; i < nomes.Count; i++)
                {
                    {
                        if (nomes[i] == nome)
                        {
                            nomes.RemoveRange(i, 1);
                            Console.WriteLine("Nome removido com sucesso.\n");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("nome não existe.\n");
            }
        }
    }

}
