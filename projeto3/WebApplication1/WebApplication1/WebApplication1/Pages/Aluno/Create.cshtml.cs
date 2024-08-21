using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Aluno
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;
        private readonly IWebHostEnvironment _env;

        public CreateModel(WebApplication1Context context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Alunos NewAluno { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Alunos == null || NewAluno == null)
            {
                return Page();
            }
            else
            {
                if (!ModelState.IsValid) { return Page(); }

                if (NewAluno.Upload is not null)
                {
                    NewAluno.ImageFile = NewAluno.Upload.FileName;

                    var file = Path.Combine
                        (_env.ContentRootPath
                            , "wwwroot/images/menu"
                            , NewAluno.Upload.FileName
                        );
                    using (var filestream = new FileStream(file, FileMode.Create))
                    {
                        NewAluno.Upload.CopyTo(filestream);
                    }

                }

                _context.Alunos.Add(NewAluno);
                _context.SaveChanges();

                return RedirectToPage("./Index");

            }  
        }
    }
}
