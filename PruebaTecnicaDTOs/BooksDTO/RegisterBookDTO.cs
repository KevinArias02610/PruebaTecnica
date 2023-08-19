using PruebaTecnicaDTOs.AuthorsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaDTOs.BooksDTO
{
    public class RegisterBookDTO
    {
        public string? AuthorFullName { get; set; }
        public string? BookTitle { get; set; }
        public decimal? BookYear { get; set; }
        public string? BookGenre { get; set; }
        public decimal? BookNumberOfPages { get; set; }
    }
}
