﻿using PruebaTecnicaDataAccess.ModelsDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaServices.Interfaces
{
    public interface IAuthorsService
    {
        List<Author> GetAllAuthors();
    }
}
