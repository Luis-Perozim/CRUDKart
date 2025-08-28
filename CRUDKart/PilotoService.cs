using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            if (string.IsNullOrWhiteSpace(nome) || nome.Any(char.IsDigit)) //verifica se o nome é nulo ou contém números
            {
                Console.WriteLine("Nome inválido. O nome não pode conter números ou ser vazio.");
                return;
            }

            Console.WriteLine("CPF: ");
            string cpf = (Console.ReadLine());
            if (!Validacao.ValidaCPF.IsCpf(cpf)) //valida o cpf usando a classe ValidaCPF
            {
                Console.WriteLine("CPF inválido. Tente novamente.");
                return;
            }
           
            Console.WriteLine("Data de nascimento: ");
            string dataString = Console.ReadLine();
            DateTime dataNascimento = DateTime.Parse(dataString);
            if (string.IsNullOrEmpty(dataString))
            {
                Console.WriteLine("Data inválida.");
                return;
            } 

            var idadeCalculada = DateTime.Now.Year - dataNascimento.Year;

            string prefixoA = "A"; // Piloto maior de idade
            string prefixoB = "B"; // Piloto menor de idade
            int numero = 1;
            string registro = string.Empty;

            for (int i = 0; i < 100000; i++)
            {
                if (idadeCalculada >= 18)
                {
                    registro = $"{prefixoA}{numero:D5}";
                }
                else
                {
                    registro = $"{prefixoB}{numero:D5}";
                }
                if (!_pilotos.Any(p => p.Registro == registro))
                {
                    break;
                }
                numero++;
            }

            _pilotos.Add(new Piloto
                {
                    Id = _proximoID++,
                    Registro = registro,
                    Nome = nome,
                    Cpf = cpf,
                    Idade = idadeCalculada,
                    DataNascimento = dataNascimento
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
                Console.WriteLine($"ID: {piloto.Id}, Registro:{piloto.Registro}, Nome: {piloto.Nome}, CPF: {piloto.Cpf}, NASC: {piloto.DataNascimento.ToString("dd/MM/yyyy")}, Idade: {piloto.Idade}");
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
            if (string.IsNullOrWhiteSpace(nome) || nome.Any(char.IsDigit)) //verifica se o nome é nulo ou contém números
            {
                Console.WriteLine("Nome inválido. O nome não pode conter números ou ser vazio.");
                return;
            }
            else
            {
                piloto.Nome = nome;
            }

            Console.WriteLine($"Correção de CPF ({piloto.Cpf})");
            string cpf = (Console.ReadLine());
            if (!Validacao.ValidaCPF.IsCpf(cpf)) //valida o cpf usando a classe ValidaCPF
            {
                Console.WriteLine("CPF inválido. Tente novamente.");
                return;
            }
            else
            {
                piloto.Cpf = cpf;
            }

            Console.WriteLine($"Correção data de nascimento: ");
            string dataString = Console.ReadLine();
            DateTime dataNascimento = DateTime.Parse(dataString);
            if (string.IsNullOrEmpty(dataString))
            {
                Console.WriteLine("Data inválida.");
                return;
            }
            else
            {
                piloto.DataNascimento = dataNascimento;
                var idadeCalculada = DateTime.Now.Year - dataNascimento.Year;
                piloto.Idade = idadeCalculada;
            }
        }

        public void Deletar()
        {
            Console.WriteLine("Informe o ID do piloto que deseja deletar: ");
            int id = int.Parse(Console.ReadLine());

            var piloto = _pilotos.FirstOrDefault(p => p.Id == id);
            if (piloto == null)
            {
                Console.WriteLine("Piloto não encontrado");
                return;
            }

            _pilotos.Remove(piloto);
            Console.WriteLine("Piloto deletado com sucesso!");
        }

    }
}
