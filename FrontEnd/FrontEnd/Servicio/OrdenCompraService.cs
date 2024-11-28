﻿using FrontEnd.Models;

namespace FrontEnd.Servicio
{
    public class OrdenCompraService //: ICompraService
    { 
    
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        string _baseURL = string.Empty;

        public OrdenCompraService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseURL = _configuration["UrlBaseAPIs"];
            _httpClient.BaseAddress = new Uri(_baseURL);            
        }

        public async Task<IEnumerable<OrdenCompra>> GetOrdenComprasAsync(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync("/DetallesOrdenCompra/ObtenerDetallesOrdenCompraTodos");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<OrdenCompra>>();
        }        

        public async Task<bool> CreateOrdenCompraAsync(OrdenCompra OrdenCompra, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJsonAsync("/DetallesOrdenCompra/InsertarDetallesOrdenCompra", OrdenCompra);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateOrdenCompraAsync(OrdenCompra OrdenCompra, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PutAsJsonAsync($"/DetallesOrdenCompra/ActualizarDetallesOrdenCompra", OrdenCompra);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteOrdenCompraAsync(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.DeleteAsync($"/DetallesOrdenCompra/EliminarDetallesOrdenCompra/{id}");
            return response.IsSuccessStatusCode;
        }


    }
}