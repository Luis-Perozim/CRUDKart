using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
    }
}
