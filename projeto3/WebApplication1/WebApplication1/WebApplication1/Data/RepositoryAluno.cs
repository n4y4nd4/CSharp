using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class RepsitoryProduct : IRepositoryAlunos
    {
        private WebApplication1Context _context;

        public void Update(Alunos product)
        {
            _context.Update(product);
            _context.SaveChanges();
        }

    }
}
