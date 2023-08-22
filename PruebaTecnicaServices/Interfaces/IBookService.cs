using PruebaTecnicaDataAccess.ModelsDB;
using PruebaTecnicaDTOs.BooksDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaServices.Interfaces
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        bool CreateBook(SaveBookDTO name);
        public List<BooksAuthorDTO> GetBooksAuthors();
        Book GetBookByName(string name);

    }
}
