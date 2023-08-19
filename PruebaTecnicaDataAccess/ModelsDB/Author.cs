using System;
using System.Collections.Generic;

namespace PruebaTecnicaDataAccess.ModelsDB
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public decimal Id { get; set; }
        public string FullName { get; set; } = null!;
        public DateTime? DateOfBirth { get; set; }
        public string? CityOfOrigin { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Book>? Books { get; set; }
    }
}
