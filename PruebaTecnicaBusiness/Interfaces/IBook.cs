using PruebaTecnicaDTOs.AuthorsDTO;
using PruebaTecnicaDTOs.BooksDTO;
using PruebaTecnicaDTOs.GenericDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PruebaTecnicaDTOs.BooksDTO.RegisterBookDTO;

namespace PruebaTecnicaBusiness.Interfaces
{
    public interface IBook
    {
        ResponseDTO RegisterBookData(RegisterBookDTO registerBookDTO);
    }
}
