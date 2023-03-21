using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AtividadeAvaliativa
{
    public class Pessoa
    {
        // atributos
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public List<Livro> LivrosEmprestados { get; set; }

        // construtor
        public Pessoa (int idPessoa, string nome, string cpf, string telefone)
        {
            Id = idPessoa;
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            LivrosEmprestados = new List<Livro>();
        }

        // métodos

        /// <summary>
        /// Add a book to the list of books borrowed
        /// </summary>
        /// <param name="livro"></param>
        public void AdicionarLivroLista (Livro livro)
        {
            LivrosEmprestados.Add(livro);
        }

        /// <summary>
        /// Remove a book from the list of borrowed books
        /// </summary>
        /// <param name="idLivro"></param>
        public void RemoverLivroLista (int idLivro)
        {
            LivrosEmprestados.RemoveAll(l => l.Id == idLivro);
        }
    }
}
