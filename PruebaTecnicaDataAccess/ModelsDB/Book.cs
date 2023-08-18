using System;
using System.Collections.Generic;

namespace PruebaTecnicaDataAccess.ModelsDB
{
    public partial class Book
    {
        public decimal Id { get; set; }
        public string Title { get; set; } = null!;
        public decimal? Year { get; set; }
        public string? Genre { get; set; }
        public decimal? NumberOfPages { get; set; }
        public decimal? AuthorId { get; set; }

        public virtual Author? Author { get; set; }
    }
}
