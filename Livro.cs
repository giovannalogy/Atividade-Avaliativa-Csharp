using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeAvaliativa
{
    public class Livro
    {
        // atributos
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public int QuantidadeExemplares { get; set; }

        // construtor

        public Livro(int idLivro, string tituloLivro, string autorLivro, string editoraLivro,
            int quantidadeExemplares)
        {
            Id = idLivro;
            Titulo = tituloLivro;
            Autor = autorLivro;
            Editora = editoraLivro;
            QuantidadeExemplares = quantidadeExemplares;

        }

        // métodos
        /// <summary>
        /// Do the math of the loan of the book 
        /// </summary>
        /// <param name="quantidadeEmprestada"></param>
        public void EmprestarLivro (int quantidadeEmprestada)
        {
            QuantidadeExemplares -= quantidadeEmprestada;
        }

        /// <summary>
        /// Do the math of the return of the book
        /// </summary>
        /// <param name="quantidadeDevolvida"></param>
        public void DevolverLivro (int quantidadeDevolvida)
        {
            QuantidadeExemplares += quantidadeDevolvida;
        }
    }

}




