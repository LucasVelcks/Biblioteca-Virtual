using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Biblioteca
{
    public class Livro
    {
        public string TituloDoLivro;
        public string NomeDoAutorDoLivro;
        public int AnoDePublicação;
        public bool IsDisponivel { get; set; } = true;

        public Livro(string tituloDoLivro, string nomeDoAutorDoLivro, int anoDePublicação)
        {
            TituloDoLivro = tituloDoLivro;
            NomeDoAutorDoLivro = nomeDoAutorDoLivro;
            AnoDePublicação = anoDePublicação;
            IsDisponivel = true;
        }

        public void EmprestarLivro()
        {
            IsDisponivel = false;
        }
        public void DevolverLivro()
        {
            IsDisponivel = true;
        }
        public override string ToString() 
        { 
            return $"{TituloDoLivro} - {NomeDoAutorDoLivro} ({AnoDePublicação})";
        }
        
    }
    public class Biblioteca
    {
        public List<Livro> Livros { get; private set; }
        public Biblioteca()
        {
            Livros = new List<Livro>();

            AdicionarLivro(new Livro("Dom Quixote", "Miguel de Cervantes", 1605));
            AdicionarLivro(new Livro("Senhor dos Anéis", "J.R.R. Tolkien", 1954));
            AdicionarLivro(new Livro("O Pequeno Príncipe", "Antoine de Saint-Exupéry", 1943));
            AdicionarLivro(new Livro("Harry Potter e a Pedra Filosofal", "J. K. Rowling", 1997));
            AdicionarLivro(new Livro("Senhora", "José de Alencar", 1875));
        }
        public void AdicionarLivro(Livro livro)
        {
            if (livro != null) 
            { 
                Livros.Add(livro);
                //Console.WriteLine($"Livro \"{livro.TituloDoLivro}\" adicionado com sucesso.");
            }
            else
            {
                Console.WriteLine("Erro: O livro não pode ser nulo.");
            }
        }

        public Livro BuscarLivroPorTitulo(string tituloDoLivro) 
        {
            foreach (var livro in Livros)
            {
                if (livro.TituloDoLivro.Equals(tituloDoLivro, StringComparison.OrdinalIgnoreCase))
                {
                    return livro;
                }
            }
            Console.WriteLine("Livro não encontrado");
            return null;
        }

        public List<Livro> ListarLivrosDisponiveis() 
        {
            return Livros.Where(livro => livro.IsDisponivel).ToList();
        }

        public void EmprestarLivro(string tituloDoLivro)
        {
            Livro livro = BuscarLivroPorTitulo(tituloDoLivro);

            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado");
                return;
            }
                if (livro.IsDisponivel)
                {
                    livro.IsDisponivel = false;
                    Console.WriteLine($"O livro \"{tituloDoLivro}\" foi emprestado com sucesso.");
                }
                else
                {
                    Console.WriteLine($"O livro \"{tituloDoLivro}\" já está emprestado.");
                }           
        }

        public void DevolverLivro(string tituloDoLivro)
        {
            Livro livro = BuscarLivroPorTitulo(tituloDoLivro);

            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado na biblioteca");
                return;
            }
                if (!livro.IsDisponivel)
                {
                    livro.IsDisponivel = true;
                    Console.WriteLine($"O livro \"{tituloDoLivro}\"foi devolvido.");
                }
                else
                {
                    Console.WriteLine("livro não encontrado");
                }
            
        }
    }

   public class Interface
    {
        public static void Main()
        {
            Biblioteca biblioteca = new Biblioteca();

            while (true)
            {
                Console.WriteLine("\nMenu da Biblioteca");
                Console.WriteLine("1. Adicionar Livro");
                Console.WriteLine("2. Buscar livro por titulo");
                Console.WriteLine("3. Listar todos os livros diponiveis");
                Console.WriteLine("4. Emprestar um Livro");
                Console.WriteLine("5. Devolver um Livro");
                Console.WriteLine("6. Sair");
                Console.WriteLine("Escolha uma opção");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Write("Digite o titulo do livro: ");
                        string titulodolivro = Console.ReadLine();
                        Console.Write("Digite o autor do livro: ");
                        string nomedoautordolivro = Console.ReadLine();
                        Console.Write("Digite o ano de publicação: ");
                        if (int.TryParse(Console.ReadLine(), out int AnoDePublicação))
                        {
                            biblioteca.AdicionarLivro(new Livro(titulodolivro, nomedoautordolivro, AnoDePublicação));
                        }
                        else
                        {
                            Console.Write("Ano de publicação inválido.");
                        }
                        break;

                    case "2":
                        Console.WriteLine("Digite o titulo do livro que deseja buscar: ");
                        string tituloBusca = Console.ReadLine();
                        Livro livroEncontrado = biblioteca.BuscarLivroPorTitulo(tituloBusca);
                        if (livroEncontrado != null)
                        {
                            Console.WriteLine($"Livro encontrado: {livroEncontrado}");
                        }
                        else
                        {
                            Console.WriteLine("Livro não encontrado.");
                        }
                        break;

                    case "3":
                        Console.WriteLine("Livros Disponiveis:");
                        List<Livro> livrosDisponiveis = biblioteca.ListarLivrosDisponiveis();
                        if (livrosDisponiveis.Count > 0)
                        {
                            foreach (var livro in livrosDisponiveis)
                            {
                                Console.WriteLine(livro);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nenhum livro disponivel para empréstimo.");
                        }
                        break;
                        
                    case "4":
                        Console.Write("Digite o titulo do livro para emprestar: ");
                        string tituloEmprestimo = Console.ReadLine();
                        biblioteca.EmprestarLivro(tituloEmprestimo);
                        break;

                    case "5":
                        Console.Write("Digite o titulo do livro para Devolver: ");
                        string tituloDevolução = Console.ReadLine();
                        biblioteca.DevolverLivro(tituloDevolução);
                        break;
                        
                    case "6":
                        Console.WriteLine("Saindo do Sistema...");
                        return;

                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;

                }
                
                
                
            }
        }
    }
     
} 
