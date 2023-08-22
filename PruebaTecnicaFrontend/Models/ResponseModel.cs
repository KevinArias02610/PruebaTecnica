namespace PruebaTecnicaFrontend.Models
{
    public class ResponseModel
    {
        public decimal? BookId { get; set; }
        public string? BookTitle { get; set; } = null!;
        public decimal? BookYear { get; set; }
        public string? BookGenre { get; set; }
        public decimal? BookNumberOfPages { get; set; }
        public decimal? AuthorId { get; set; }
        public string? AuthorFullName { get; set; } = null!;
        public string? AuthorDateOfBirth { get; set; }
        public string? AuthorCityOfOrigin { get; set; }
        public string? AuthorEmail { get; set; }
    }
}
