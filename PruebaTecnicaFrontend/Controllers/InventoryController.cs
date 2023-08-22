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
                NumeroModel json = JsonConvert.DeserializeObject<NumeroModel>(content)!;
                numero.Numero = json.Numero;
            }
            return View(numero);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateNumberOfRecords(int records)
        {
            var content = new StringContent(records.ToString(), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync("/Inventory/UpdateNumberOfRecords", content);
            var responseBody = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<bool>(responseBody);

            TempData.Clear();
            if (apiResponse)
            {
                TempData["SuccessMessage"] = "Cantidad máxima de registros actualizada.";
            }
            else
            {
                TempData["ErrorMessage"] = "Ocurrió un error.";
            }
            return View();

        }
        #endregion
    }
}
