using FrontEnd.Models;

namespace FrontEnd.Servicio
{
    public class ProveedorService //: IProveedorService
    { 
    
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        string _baseURL = string.Empty;

        public ProveedorService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseURL = _configuration["UrlBaseAPIs"];
            _httpClient.BaseAddress = new Uri(_baseURL);            
        }

        public async Task<IEnumerable<Proveedor>> GetProveedorsAsync(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync("Proveedor/ObtenerProveedorTodos");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Proveedor>>();
        }        

        public async Task<bool> CreateProveedorAsync(Proveedor proveedor, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJsonAsync("Proveedor/InsertarProveedor", proveedor);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateProveedorAsync(Proveedor proveedor, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PutAsJsonAsync($"Proveedor/ActualizarProveedor", proveedor);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProveedorAsync(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.DeleteAsync($"Proveedor/EliminarProveedor/{id}");
            return response.IsSuccessStatusCode;
        }


    }
}
