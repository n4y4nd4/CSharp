using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace WebApplication1.Models
{
    public class Alunos { 
    
        public int Id {  get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Endereco { get; set; }
        
        [Required]
        public string CPF { get; set; }

        [Required]
        public int Matricula { get; set; }

        public string? ImageFile { get; set; }

        public string? ImageFileName { get; set; }

        [Required]
        public DateTime Created {  get; set; }

        [NotMapped]
        public IFormFile Upload { get; set; }
    }
}
