using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaDTOs.AuthorsDTO
{
    public class SaveAuthorDTO
    {
        public string? FullName { get; set; } = null!;
        public DateTime? DateOfBirth { get; set; }
        public string? CityOfOrigin { get; set; }
        public string? Email { get; set; }
    }
}
