

namespace GerenciamentoBiblioteca.Business
{
    public class Livro
    {
        private int _id;
        private string _titulo;
        private string _autor;
        private DateTime _dataPublicacao;
        private double _preco;
        private bool _disponivel;

        public Livro(int id, string titulo, string autor, DateTime dataPublicacao, double preco, bool disponivel)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            DataPublicacao = dataPublicacao;
            Preco = preco;
            Disponivel = disponivel;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }

        public string Autor
        {
            get { return _autor; }
            set { _autor = value; }
        }

        public DateTime DataPublicacao
        {
            get { return _dataPublicacao; }
            set { _dataPublicacao = value; }
        }

        public double Preco
        {
            get { return _preco; }
            set { _preco = value; }
        }

        public bool Disponivel
        {
            get { return _disponivel; }
            set { _disponivel = value; }
        }

       

    }



}