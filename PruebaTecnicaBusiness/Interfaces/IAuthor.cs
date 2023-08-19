using PruebaTecnicaDTOs.AuthorsDTO;
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
    }
}
