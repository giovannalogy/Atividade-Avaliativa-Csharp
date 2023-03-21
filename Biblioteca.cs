using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeAvaliativa
{
    public class Biblioteca
    {
        // atributs
        public List<Pessoa> Pessoas { get; set; }
        public List<Livro> Livros { get; set; }


        // constructor
        public Biblioteca()
        {
            Pessoas = new List<Pessoa>();
            Livros = new List<Livro>();
        }

        // methods

        /// <summary>
        /// Register the person in the list of people
        /// </summary>
        /// <param name="pessoa"></param>
        public void CadastrarPessoa(Pessoa pessoa)
        {
            Pessoas.Add(pessoa);
        }

        /// <summary>
        /// Register the book in the list of books
        /// </summary>
        /// <param name="livro"></param>
        public void CadastrarLivro(Livro livro)
        {
            Livros.Add(livro);
        }

        /// <summary>
        /// See if a person already exists in the list of people
        /// </summary>
        /// <param name="PessoaID"></param>
        /// <returns></returns>
        public bool VerifyPersonId(int PessoaID)
        {

            if (Pessoas.Exists(p => p.Id == PessoaID))
            {
                return true;
            }

            return false;   
        }

        /// <summary>
        /// Verify if a book exists by the id
        /// </summary>
        /// <param name="BookID"></param>
        /// <returns></returns>
        public bool VerifyBookId(int BookID)
        {

            if (Livros.Exists(l => l.Id == BookID))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Find the title of a book by the id
        /// </summary>
        /// <param name="BookID"></param>
        /// <returns></returns>
        public string GetBookTitleById(int BookID)
        {
            return Livros.Find(l => l.Id == BookID).Titulo;
        }

       
        /// <summary>
        /// Find the name of the person by the id
        /// </summary>
        /// <param name="PersonID"></param>
        /// <returns></returns>
        public string GetPersonNameById(int PersonID)
        {
            return Pessoas.Find(p => p.Id == PersonID).Nome;
        }
    
        /// <summary>
        /// Find the person and the book and call the method to borrow the book
        /// This method is if a book is different than null and a person is different than null
        /// the book is borrowed and the person(and book) is added to the list of books borrowed
        /// </summary>
        /// <param name="idLivro"></param>
        /// <param name="idPessoa"></param>
        public void EmprestarLivroBiblioteca(int idLivro, int idPessoa)
        {
            Livro livro = Livros.Find(l => l.Id == idLivro);
            Pessoa pessoa = Pessoas.Find(p => p.Id == idPessoa);

            if (livro != null && pessoa != null)
            {
                livro.EmprestarLivro(1);
                pessoa.AdicionarLivroLista(livro);
            }
        }

        /// <summary>
        /// Find the book and the person by the id and call a method to return the book
        /// This method is the same as the one before 
        /// </summary>
        /// <param name="idLivro"></param>
        /// <param name="idPessoa"></param>
        public void DevolverLivroBiblioteca(int idLivro, int idPessoa)
        {
            Livro livro = Livros.Find(l => l.Id == idLivro);
            Pessoa pessoa = Pessoas.Find(p => p.Id == idPessoa);

            if (livro != null && pessoa != null)
            {
                livro.DevolverLivro(1);
                pessoa.RemoverLivroLista(idLivro);
            }
        }

    }
}