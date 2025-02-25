﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Aluno
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;

        public IndexModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context;
        }

        public IList<Alunos> Alunos { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Alunos != null)
            {
                Alunos = await _context.Alunos.ToListAsync();
            }
        }
    }
}
