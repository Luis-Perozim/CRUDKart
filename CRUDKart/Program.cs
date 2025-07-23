using CRUDKart;
using System;

class Program 
{ 
    static void Main()
    {
        {
            var service = new PilotoService();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("---Cadastro de Pilotos---");
                Console.WriteLine("1. Cadastrar pilotos");
                Console.WriteLine("2. Listar pilotos");
                Console.WriteLine("3. Editar pilotos");
                Console.WriteLine("4. Remover piloto");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        service.Cadastrar();
                        break;
                    case "2":
                        service.Listar();
                        break;
                    case "3":
                        service.Editar();
                        break;
                    case "4":
                        service.Deletar();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }





}
