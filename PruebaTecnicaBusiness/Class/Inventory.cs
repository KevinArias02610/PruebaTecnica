using PruebaTecnicaBusiness.Interfaces;
using PruebaTecnicaServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaBusiness.Class
{
    public class Inventory : IInventory
    {
        private readonly IInventoryService _inventoryService;
        public Inventory(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService; //Inyección de interfaz de servicios inventoryService
        }
        public bool UpdateNumberOfRecords(int quantity)
        {
            try
            {
                return _inventoryService.UpdateNumberOfRecords(quantity); //Consumimos el servicio de actualizacion
            }
            catch
            {
                return false; //Error actualizando el registro
            }
        }
    }
}
