using PruebaTecnicaBusiness.Interfaces;
using PruebaTecnicaDTOs.AuthorsDTO;
using PruebaTecnicaDTOs.BooksDTO;
using PruebaTecnicaDTOs.GenericDTO;
using PruebaTecnicaServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PruebaTecnicaDTOs.BooksDTO.RegisterBookDTO;

namespace PruebaTecnicaBusiness.Class
{
    public class Book : IBook
    {
        private readonly IBookService _bookService;
        private readonly IInventoryService _inventoryService;
        private readonly IAuthorsService _authorsService;
        public Book(IBookService bookService, IAuthorsService authorsService, IInventoryService inventoryService)
        {
            //Inyección de interfaces
            _authorsService = authorsService;
            _inventoryService = inventoryService;
            _bookService = bookService;
        }

        public List<BooksAuthorDTO> GetAllBooks()
        {
            List<BooksAuthorDTO> response = new();
            try
            {
                return _bookService.GetBooksAuthors();
            }
            catch (Exception ex)
            {
                return response;
            }
        }

        public ResponseDTO RegisterBookData(RegisterBookDTO registerBookDTO)
        {
            ResponseDTO response = new();
            try
            {
                #region validate inputs
                if (string.IsNullOrEmpty(registerBookDTO.AuthorFullName))
                    throw new Exception("Complete la información del autor.");

                if (string.IsNullOrEmpty(registerBookDTO.BookGenre) || !registerBookDTO.BookNumberOfPages.HasValue || string.IsNullOrEmpty(registerBookDTO.BookTitle) || !registerBookDTO.BookYear.HasValue)
                    throw new Exception("Complete la información del libro.");
                #endregion

                var author = _authorsService.GetAuthorByName(registerBookDTO.AuthorFullName!);
                if (author is null)
                    throw new Exception("El autor no está registrado.");

                else
                {
                    int numberOfRecords = _inventoryService.GetNumberOfRecords();
                    var books = _bookService.GetAllBooks();

                    if(books.Count >= numberOfRecords)
                        throw new Exception("No es posible registrar el libro, se alcanzó el máximo permitido.");

                    _bookService.CreateBook(new SaveBookDTO()
                    {
                        Year = registerBookDTO.BookYear,
                        Title = registerBookDTO.BookTitle,
                        Genre = registerBookDTO.BookGenre,
                        NumberOfPages = registerBookDTO.BookNumberOfPages,
                        AuthorId = author.Id
                    });

                    response.Status = "Ok";
                    response.Message = "Libro creado correctamente.";
                }                
            }
            catch(Exception ex)
            {
                response.Status = "Error";
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
