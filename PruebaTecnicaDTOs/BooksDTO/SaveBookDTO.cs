using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaDTOs.BooksDTO
{
    public class SaveBookDTO
    {
        public string Title { get; set; } = null!;
        public decimal? Year { get; set; }
        public string? Genre { get; set; }
        public decimal? NumberOfPages { get; set; }
        public decimal? AuthorId { get; set; }
    }
}
