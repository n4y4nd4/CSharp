
using GerenciamentoBiblioteca.Business;
using GerenciamentoBiblioteca.Data;

namespace GerenciamentoBiblioteca.cs
{
    class Program
    {
        static void Main(string[] args)
        {

            // Livro livro = new Livro();


            Console.Clear();
            Console.WriteLine("Qual repositório deseja utilizar?");
            Console.WriteLine("1. Arquivo");
            Console.WriteLine("2. Memória");
            ILivro repositorio = null;

            int escolhaRepositorio;
            int.TryParse(Console.ReadLine(), out escolhaRepositorio);

            switch (escolhaRepositorio)
            {
                case 1:

                    repositorio = new LivroArquivo();
                    break;

                case 2:

                    repositorio = new LivroMemoria();
                    break;


            }

            bool sair = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Gerenciamento de Biblioteca - Menu Principal");
                Console.WriteLine("1. Incluir Livro");
                Console.WriteLine("2. Alterar Livro");
                Console.WriteLine("3. Excluir Livro");
                Console.WriteLine("4. Pesquisar Livro");
                Console.WriteLine("5. Sair");



                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":

                        repositorio.IncluirLivro();
                        break;

                    case "2":

                        repositorio.AlterarLivro();
                        break;

                    case "3":
                        repositorio.ExcluirLivro();
                        break;

                    case "4":
                        repositorio.PesquisarLivro();
                        break;

                    case "5":
                        sair = true;
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();

            } while (sair == false);

            Console.WriteLine("Programa encerrado.");
        }
    }
}