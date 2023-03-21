using System.Runtime.CompilerServices;

namespace AtividadeAvaliativa
{
    public class Program
    {
        static void Main(string[] args)
        {
            // instanciar a biblioteca
            Biblioteca biblioteca = new Biblioteca();
            // fazer o menu
            int opcao = 0;
            do
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1 - Cadastrar Pessoa");
                Console.WriteLine("2 - Cadastrar Livro");
                Console.WriteLine("3 - Emprestar Livro");
                Console.WriteLine("4 - Devolver Livro");
                Console.WriteLine("5 - Listar todos os livros");
                Console.WriteLine("6 - Listar todas as pessoas cadastradas");
                Console.WriteLine("7 - Listar todos os livros emprestados");
                Console.WriteLine("0 - Sair");

                Console.Write("Opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {

                    case 1:
                        // Add a new person to the list while checking if the id already exists
                        Console.WriteLine("Cadastro de Pessoa:");
                        Console.Write("Id: ");
                        int idPessoa = int.Parse(Console.ReadLine());
                        if (biblioteca.VerifyPersonId(idPessoa))
                        {
                            Console.WriteLine("Pessoa já cadastrada.");

                            break;
                        }
                        Console.Write("Nome: ");
                        string nomePessoa = Console.ReadLine();
                        Console.Write("CPF: ");
                        string cpfPessoa = Console.ReadLine();
                        Console.Write("Telefone: ");
                        string telefonePessoa = Console.ReadLine();
                        Pessoa novaPessoa = new Pessoa(idPessoa, nomePessoa, cpfPessoa, telefonePessoa);
                        biblioteca.CadastrarPessoa(novaPessoa);
                        Console.WriteLine("Pessoa cadastrada com sucesso!");
                        break;
                    

                    case 2: //Put a book on the List checking if the book already exists
                        Console.WriteLine("Cadastro de Livro:");
                        Console.Write("Id: ");
                        int idLivro = int.Parse(Console.ReadLine());
                        if (biblioteca.VerifyBookId(idLivro))
                        {
                            Console.WriteLine("Livro já cadastrado.");
                            break;
                        }
                        Console.Write("Título: ");
                        string tituloLivro = Console.ReadLine();
                        Console.Write("Autor: ");
                        string autorLivro = Console.ReadLine();
                        Console.Write("Editora: ");
                        string editoraLivro = Console.ReadLine();
                        Console.Write("Quantidade de exemplares: ");
                        int quantidadeExemplares = int.Parse(Console.ReadLine());
                        Livro novoLivro = new Livro(idLivro, tituloLivro, autorLivro, editoraLivro,
                            quantidadeExemplares);
                        biblioteca.CadastrarLivro(novoLivro);
                        Console.WriteLine("Livro cadastrado com sucesso!");
                        break;

                    case 3:  //Lend a book using methods to check the id and the title of the book
                             //and the name of the person 
                        Console.WriteLine("Emprestar Livro:"); //Lend a book
                        Console.Write("Id do Livro: "); //book ID you want to rent
                        int idLivroEmprestimo = int.Parse(Console.ReadLine());
                        if (biblioteca.VerifyBookId(idLivroEmprestimo))
                        {
                            Console.WriteLine("Livro encontrado."); //This Book exists
                        }
                        else
                        {
                            Console.WriteLine("Livro não cadastrado.");//Book does not exists
                            break;
                        }
                        Console.Write("Id da Pessoa: "); //ID of the person that wants to lend the book
                        int idPessoaEmprestimo = int.Parse(Console.ReadLine());
                        if (biblioteca.VerifyPersonId(idPessoaEmprestimo))
                        {
                            Console.WriteLine("Cadastro de pessoa encontrado.");
                        }
                        else
                        {
                            Console.WriteLine("Pessoa não cadastrada.");
                            break;
                        }
                        biblioteca.EmprestarLivroBiblioteca(idLivroEmprestimo, idPessoaEmprestimo);
                        Console.WriteLine("Livro Emprestado com Sucesso!");
                        Console.WriteLine($"O livro {biblioteca.GetBookTitleById(idLivroEmprestimo)} " +
                                          $"foi emprestado para {biblioteca.GetPersonNameById(idPessoaEmprestimo)}");
                        break;

                    // return book using methods to check the id and the title of the book
                    //and the name of the person 
                    case 4:
                        Console.WriteLine("Devolver Livro:");
                        Console.Write("Id do Livro: ");
                        int idLivroDevolucao = int.Parse(Console.ReadLine());
                        if (biblioteca.VerifyBookId(idLivroDevolucao))
                        {
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Livro não cadastrado.");
                            break;
                        }
                        Console.Write("Id da Pessoa: ");
                        int idPessoaDevolucao = int.Parse(Console.ReadLine());
                        if (biblioteca.VerifyPersonId(idPessoaDevolucao))
                        {
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Pessoa não cadastrada.");
                            break;
                        }
                        biblioteca.DevolverLivroBiblioteca(idLivroDevolucao, idPessoaDevolucao);
                        Console.WriteLine("Livro Devolvido com Sucesso!");
                        Console.WriteLine($"O livro {biblioteca.GetBookTitleById(idLivroDevolucao)} " +
                                           $"foi devolvido por {biblioteca.GetPersonNameById(idPessoaDevolucao)}");

                        break;
                        // list all book
                    case 5:
                        Console.WriteLine("Listar todos os livros:");
                        foreach (Livro livro in biblioteca.Livros)
                        {
                            Console.WriteLine($"Id: {livro.Id} - Título: {livro.Titulo} - Autor: {livro.Autor} - Editora: {livro.Editora} - Disponibilidade: {livro.QuantidadeExemplares}");
                        }
                        break;


                        // list all people
                    case 6:
                        Console.WriteLine("Listar todas as pessoas cadastradas:");
                        foreach (Pessoa pessoa in biblioteca.Pessoas)
                        {
                            Console.WriteLine($"Id: {pessoa.Id} - Nome: {pessoa.Nome} - CPF: {pessoa.Cpf} - Telefone: {pessoa.Telefone}");
                        }
                        break;


                        // list all borrowed books using a foreach to check if the list is empty
                        // and use the if count to see if theres any book on the list of borrowed books
                    case 7:
                        Console.WriteLine("Listar todos os livros emprestados:");
                        foreach (Pessoa pessoa in biblioteca.Pessoas)
                        {

                            if (pessoa.LivrosEmprestados.Count > 0)
                            {
                                foreach (Livro livro in pessoa.LivrosEmprestados)
                                {
                                    
                                        Console.WriteLine($"Id: {livro.Id} - Título: {livro.Titulo} - Autor: {livro.Autor} - Editora: {livro.Editora} - Disponibilidade: {livro.QuantidadeExemplares}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Não há livros emprestados! ");
                            }

                            
                        }
                        break;

                }
                
             // when you hit 0, the menu closes

            } while (opcao != 0);
        }
    }
}
