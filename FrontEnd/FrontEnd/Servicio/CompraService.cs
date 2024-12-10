using FrontEnd.Models;

namespace FrontEnd.Servicio
{
    public class CompraService //: ICompraService
    { 
    
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        string _baseURL = string.Empty;

        public CompraService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseURL = _configuration["UrlBaseAPIs"];
            _httpClient.BaseAddress = new Uri(_baseURL);            
        }

        public async Task<IEnumerable<Compra>> GetComprasAsync(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync("Compra/ObtenerCompraTodos");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Compra>>();
        }        

        public async Task<bool> CreateCompraAsync(Compra Compra, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJsonAsync("Compra/InsertarCompra", Compra);
            return response.IsSuccessStatusCode;
        }

        public async Task<Compra> GetCompraIdAsync(Int32 nIdCompra, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync($"Compra/GetCompraId/{nIdCompra}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Compra>();
        }

        public async Task<bool> UpdateCompraAsync(Compra Compra, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PutAsJsonAsync($"Compra/ActualizarCompra", Compra);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCompraAsync(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.DeleteAsync($"Compra/EliminarCompra/{id}");
            return response.IsSuccessStatusCode;
        }


    }
}
