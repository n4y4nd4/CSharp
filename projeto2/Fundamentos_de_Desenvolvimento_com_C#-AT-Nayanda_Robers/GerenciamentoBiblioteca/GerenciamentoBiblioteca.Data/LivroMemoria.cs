using GerenciamentoBiblioteca.Business;


namespace GerenciamentoBiblioteca.Data
{

    public class LivroMemoria : ILivro
    {
        private List<Livro> livros;

        public LivroMemoria()
        {
            livros = new List<Livro>();

        }

        public void IncluirLivro()
        {
            Console.WriteLine("Informe o ID do livro: ");
            int.TryParse(Console.ReadLine(), out int id);

            Console.WriteLine("Informe o título do livro: ");
            string titulo = Console.ReadLine();

            Console.WriteLine("Informe o autor: ");
            string autor = Console.ReadLine();

            Console.WriteLine("Informe a data de publicação do livro (DD/MM/AAAA): ");
            DateTime.TryParse(Console.ReadLine(), out DateTime dataPublicacao);

            Console.WriteLine("Informe o preço do aluguel do livro: ");
            double.TryParse(Console.ReadLine(), out double preco);

            Console.WriteLine("O livro está disponível para alugar? (Digite True para (Sim) ou False para (Não) ) ");
            bool.TryParse(Console.ReadLine(), out bool disponivel);

            Livro novoLivro = new Livro(id, titulo, autor, dataPublicacao, preco, disponivel);



            livros.Add(novoLivro);

            Console.WriteLine("Livro incluído com sucesso!");
        }

        public void AlterarLivro()
        {
            Console.Write("Informe o ID do livro que deseja alterar: ");
            if (int.TryParse(Console.ReadLine(), out int idAlteracao))
            {
                Livro livroExistente = livros.FirstOrDefault(l => l.Id == idAlteracao);
                if (livroExistente != null)
                {
                    Console.Write("Informe o novo título do livro: ");
                    string novoTitulo = Console.ReadLine();

                    Console.Write("Informe o novo autor do livro: ");
                    string novoAutor = Console.ReadLine();

                    Console.Write("Informe a nova data de publicação do livro (DD/MM/AAAA): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime novaDataPublicacao))
                    {
                        Console.Write("Informe o novo preço do livro: ");
                        if (double.TryParse(Console.ReadLine(), out double novoPreco))
                        {
                            Console.Write("O livro está disponível para alugar? (Digite True para (Sim) ou False para (Não) ): ");
                            if (bool.TryParse(Console.ReadLine(), out bool novoDisponivel))
                            {

                                livroExistente.Titulo = novoTitulo;
                                livroExistente.Autor = novoAutor;
                                livroExistente.DataPublicacao = novaDataPublicacao;
                                livroExistente.Preco = novoPreco;
                                livroExistente.Disponivel = novoDisponivel;

                                Console.WriteLine("Livro alterado com sucesso.");
                            }
                            else { Console.WriteLine("Resposta inválida"); }
                        }
                        else
                        {
                            Console.WriteLine("Preço inválido. Nenhuma alteração foi realizada.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Data de publicação inválida. Nenhuma alteração foi realizada.");
                    }
                }
                else
                {
                    Console.WriteLine("Livro não encontrado com o ID informado.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido. Tente novamente.");
            }
        }



        public void ExcluirLivro()
        {
            Console.WriteLine("Exclusão de Livro");
            Console.WriteLine("Informe o ID do livro que deseja excluir: ");
            if (int.TryParse(Console.ReadLine(), out int idExclusao))
            {
                var livroExistente = livros.FirstOrDefault(l => l.Id == idExclusao);
                if (livroExistente != null)
                {
                    livros.Remove(livroExistente);
                    Console.WriteLine($"Livro ID {idExclusao} excluído com sucesso.");
                }
                else
                {
                    Console.WriteLine($"Livro ID {idExclusao} não encontrado. Nenhuma exclusão realizada.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido. Nenhuma exclusão realizada.");
            }
        }

        public void PesquisarLivro()
        {
            Console.WriteLine("Informe o ID do livro: ");
            if (int.TryParse(Console.ReadLine(), out int idPesquisa))
            {
                var livroEncontrado = livros.FirstOrDefault(l => l.Id == idPesquisa);
                if (livroEncontrado != null)
                {
                    Console.WriteLine($"Livro encontrado: (ID: {livroEncontrado.Id}) (Título: {livroEncontrado.Titulo}) (Autor: {livroEncontrado.Autor}) (Preço: R${livroEncontrado.Preco}) (Data de Publicação: {livroEncontrado.DataPublicacao.ToString("d")}) (Disponível: {livroEncontrado.Disponivel})");

                }
                else
                {
                    Console.WriteLine("Livro não encontrado.");

                }
            }
            else
            {
                Console.WriteLine("ID inválido. Tente novamente.");

            }
        }


        public List<Livro> ListarLivros()
        {
            return livros;
        }

        
    }
}