using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CRUDKart
{
    public class PilotoService
    {
        private readonly List<Piloto> _pilotos = new();
        private int _proximoID = 1;

        public void Cadastrar()
        {
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("CPF: ");
            int cpf = int.Parse(Console.ReadLine());

            Console.WriteLine("Idade: ");
            int idade = int.Parse(Console.ReadLine());

            _pilotos.Add(new Piloto
            {
                Id = _proximoID++,
                Nome = nome,
                Cpf = cpf,
                Idade = idade
            });

            Console.WriteLine("Piloto cadastrado com sucesso!");
        }

        public void Listar()
        {
            if (!_pilotos.Any())
            {
                Console.WriteLine("Nenhum piloto cadastrado.");
                return;
            }
            foreach (var piloto in _pilotos)
            {
                Console.WriteLine($"ID: {piloto.Id}, Nome: {piloto.Nome}, CPF: {piloto.Cpf}, Idade: {piloto.Idade}");
            }
        }

        public void Editar()
        {
            Console.WriteLine("Informe o ID do piloto que deseja editar: ");
            int id = int.Parse(Console.ReadLine());

            var piloto = _pilotos.FirstOrDefault(p => p.Id == id);
            if (piloto == null)
            {
                Console.WriteLine("Piloto não encontrado");
                return;
            }

            Console.WriteLine($"Correção de nome ({piloto.Nome}): ");
            string nome = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nome))
            {
                piloto.Nome = nome;
            }

            Console.WriteLine($"Correção de idade ({piloto.Idade})");
            if (int.TryParse(Console.ReadLine(), out int idade))
            {
                piloto.Idade = idade;
            }

            Console.WriteLine($"Correção de CPF ({piloto.Cpf})");
            if (int.TryParse(Console.ReadLine(), out int cpf))
            {
                piloto.Cpf = cpf;
            }
        }

    }
}
