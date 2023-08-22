using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PruebaTecnicaFrontend.Models;
using System.Text;

namespace PruebaTecnicaFrontend.Controllers
{
    public class InventoryController : Controller
    {
        private readonly HttpClient _httpClient;

        public InventoryController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7130");
        }

        #region UpdateNumberOfRecords
        public IActionResult UpdateNumberOfRecords()
        {
            var numero = new NumeroModel();
            HttpResponseMessage response = _httpClient.GetAsync("/Inventory/GetNumberOfRecords").Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                numero.Numero = Convert.ToInt32(content);
            }
            return View(numero);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateNumberOfRecords(NumeroModel records)
        {
            var numero = new NumeroModel();
            var content = new StringContent(records.Numero.ToString(), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("/Inventory/UpdateNumberOfRecords", content);
            var responseBody = await response.Content.ReadAsStringAsync();
            bool apiResponse = bool.Parse(responseBody);
            TempData.Clear();

            if (apiResponse)
            {
                numero.Numero = records.Numero;
                TempData["SuccessMessage"] = "Cantidad máxima de registros actualizada.";
            }
            else
            {
                TempData["ErrorMessage"] = "Ocurrió un error.";
            }
            return View(numero);
        }
        #endregion
    }
}
