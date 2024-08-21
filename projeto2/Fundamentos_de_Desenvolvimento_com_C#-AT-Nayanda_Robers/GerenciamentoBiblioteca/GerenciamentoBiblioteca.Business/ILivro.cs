
namespace GerenciamentoBiblioteca.Business
{
        public interface ILivro
        {
            void IncluirLivro();
            void AlterarLivro();
            void ExcluirLivro();
            void PesquisarLivro();
            List<Livro> ListarLivros();
        }
 }
