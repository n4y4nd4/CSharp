using System;
using System.Collections.Generic;

namespace Tp3Ccharp.Models
{
    public partial class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; } = null!;
        public int? Price { get; set; }
    }
}
