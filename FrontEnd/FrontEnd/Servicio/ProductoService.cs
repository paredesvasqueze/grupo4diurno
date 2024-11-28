using FrontEnd.Models;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using System.Configuration;


namespace FrontEnd.Servicio
{
    public class ProductoService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        string _baseURL = string.Empty;

        public ProductoService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseURL = _configuration["UrlBaseAPIs"];
            _httpClient.BaseAddress = new Uri(_baseURL);           
        }

        // Obtener la lista de productos
        public async Task<IEnumerable<Producto>> GetProductosAsync( string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync("Producto/ObtenerProductoTodos");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Producto>>();            
        }

        // Obtener producto
        public async Task<Producto> GetProductoAsync(Int32 nIdProducto, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync($"Producto/GetProductoId/{nIdProducto}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Producto>();
        }


        // Crear un nuevo producto
        public async Task<bool> CreateProductoAsync(Producto producto, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJsonAsync("Producto/InsertarProducto", producto);
            return response.IsSuccessStatusCode;
        }

        // Actualizar un producto existente
        public async Task<bool> UpdateProductoAsync(Producto producto, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PutAsJsonAsync($"Producto/ActualizarProducto", producto);
            return response.IsSuccessStatusCode;
        }

        // Eliminar un producto
        public async Task<bool> DeleteProductoAsync(int nIdProducto, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.DeleteAsync($"Producto/EliminarProducto/{nIdProducto}");
            return response.IsSuccessStatusCode;
        }
    }


}
