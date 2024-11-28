using FrontEnd.Models;

namespace FrontEnd.Servicio
{
    public class CategoriaService //: ICategoriaService
    { 
    
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        string _baseURL = string.Empty;

        public CategoriaService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseURL = _configuration["UrlBaseAPIs"];
            _httpClient.BaseAddress = new Uri(_baseURL);            
        }

        public async Task<IEnumerable<Categoria>> GetCategoriasAsync(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync("Categoria/ObtenerCategoriaTodos");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Categoria>>();
        }        

        public async Task<bool> CreateCategoriaAsync(Categoria categoria, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJsonAsync("Categoria/InsertarCategoria", categoria);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateCategoriaAsync(Categoria categoria, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PutAsJsonAsync($"Categoria/ActualizarCategoria", categoria);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCategoriaAsync(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.DeleteAsync($"Categoria/EliminarCategoria/{id}");
            return response.IsSuccessStatusCode;
        }


    }
}
