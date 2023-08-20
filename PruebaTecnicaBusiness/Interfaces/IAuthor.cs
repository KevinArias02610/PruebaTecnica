using PruebaTecnicaDTOs.AuthorsDTO;
using PruebaTecnicaDTOs.BooksDTO;
using PruebaTecnicaDTOs.GenericDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaBusiness.Interfaces
{
    public interface IAuthor
    {
        List<AuthorDTO> GetAllAuthors();
        AuthorDTO GetAuthorById(int id);
        ResponseDTO RegisterAuthor(RegisterAuthorDTO registerBookDTO);

    }
}
