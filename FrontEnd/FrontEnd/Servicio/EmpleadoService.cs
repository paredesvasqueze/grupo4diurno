using FrontEnd.Models;

namespace FrontEnd.Servicio
{
    public class EmpleadoService //: IEmpleadoService
    { 
    
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        string _baseURL = string.Empty;

        public EmpleadoService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseURL = _configuration["UrlBaseAPIs"];
            _httpClient.BaseAddress = new Uri(_baseURL);            
        }

        public async Task<IEnumerable<Empleado>> GetEmpleadosAsync(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync("Empleado/ObtenerEmpleadoTodos");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Empleado>>();
        }        

        public async Task<bool> CreateEmpleadoAsync(Empleado Empleado, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJsonAsync("Empleado/InsertarEmpleado", Empleado);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateEmpleadoAsync(Empleado Empleado, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PutAsJsonAsync($"Empleado/ActualizarEmpleado", Empleado);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteEmpleadoAsync(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.DeleteAsync($"Empleado/EliminarEmpleado/{id}");
            return response.IsSuccessStatusCode;
        }


    }
}
