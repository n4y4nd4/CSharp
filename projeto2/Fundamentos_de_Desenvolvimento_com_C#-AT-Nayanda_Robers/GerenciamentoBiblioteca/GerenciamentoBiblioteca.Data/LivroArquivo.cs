
using GerenciamentoBiblioteca.Business;

namespace GerenciamentoBiblioteca.Data
{
    public class LivroArquivo : ILivro
    {
        private static string path = "livro.txt";
        private List<Livro> livros;

        public LivroArquivo()
        {
            if (File.Exists(path))
            {
                livros = CarregarLivros();
            }
            else
            {
                livros = new List<Livro>();
            }
        }

        private List<Livro> CarregarLivros()
        {
            var livrosCarregados = new List<Livro>();

            try
            {
                string[] linhas = File.ReadAllLines(path);
                foreach (string linha in linhas)
                {
                    string[] dados = linha.Split(';');
                    if (dados.Length == 6)
                    {
                        var livro = new Livro(
                            int.Parse(dados[0]),
                            dados[1],
                            dados[2],
                            DateTime.Parse(dados[3]),
                            double.Parse(dados[4]),
                            bool.Parse(dados[5])
                        );
                        livrosCarregados.Add(livro);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar livros: {ex.Message}");
            }

            return livrosCarregados;
        }

        private void SalvarLivros()
        {
            try
            {
                var linhas = livros.Select(a => $"{a.Id};{a.Titulo};{a.Autor};{a.DataPublicacao:dd/MM/yyyy};{a.Preco};{a.Disponivel}");
                File.WriteAllLines(path, linhas);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar livros: {ex.Message}");
            }
        }

        
        public void IncluirLivro()
        {
            Console.WriteLine("Incluir Livro");
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

            Console.WriteLine("O livro está disponível para alugar? (Digite True para (Sim) ou False para (Não) )");

            bool.TryParse(Console.ReadLine(), out bool disponivel);

            Livro novoLivro = new Livro(id, titulo, autor, dataPublicacao, preco, disponivel);

            livros.Add(novoLivro);

            SalvarLivros();

            Console.WriteLine("Livro incluído com sucesso!");
        }

        public void AlterarLivro()
        {
            Console.WriteLine("Alterar Livro");
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

                                SalvarLivros();

                                Console.WriteLine("Livro alterado com sucesso.");
                            }
                            else
                            {
                                Console.WriteLine("Resposta inválida");
                            }
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
            Console.WriteLine("Excluir Livro");
            Console.WriteLine("Informe o ID do livro que deseja excluir: ");
            if (int.TryParse(Console.ReadLine(), out int idExclusao))
            {
                var livroExistente = livros.FirstOrDefault(l => l.Id == idExclusao);
                if (livroExistente != null)
                {
                    livros.Remove(livroExistente);
                    SalvarLivros();
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
            Console.WriteLine("Pesquisar Livro");
            Console.WriteLine("Informe o ID do livro: ");
            int.TryParse(Console.ReadLine(), out int idPesquisa);

            if (idPesquisa != null)
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
