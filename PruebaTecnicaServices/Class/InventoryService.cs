using PruebaTecnicaDataAccess.ContextDB;
using PruebaTecnicaServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaServices.Class
{
    public class InventoryService : IInventoryService
    {
        ModelContext contextdb = new ModelContext();
        public bool UpdateNumberOfRecords(int quantity)
        {
            try
            {
                var response = contextdb.Inventories.FirstOrDefault(inv => inv.Id == 1);

                if (response != null)
                {
                    response.NumberOfRecords = quantity; //Actualizamos la cantidad de registros permitidos
                    contextdb.SaveChanges(); //guardamos los cambios
                    return true;// Actualización exitosa
                }

                return false; // Error al actualizar actualizar

            }
            catch
            {
                return false; // Error al actualizar
            }
        }
    }
}
