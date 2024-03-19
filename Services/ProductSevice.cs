using ClassLibrary1.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorApp1.Client.Services
{
    public class ProductSevice
    {
        private readonly HttpClient http;

        private string apiLink = "/api/ProductCategories";

        public ProductSevice(HttpClient http, NavigationManager nav)
        {
            http.BaseAddress = new Uri(nav.BaseUri);
            this.http = http;
        }

        public async Task<IList<ProductCategory>?> GetAll()
        {
            var data = await this.http.GetFromJsonAsync<IList<ProductCategory>>(apiLink);
            return data;
        }
        public async Task<ProductCategory?> GetById(int id)
        {
            return await this.http.GetFromJsonAsync<ProductCategory>(apiLink + $"/{id}");
        }
        public async Task<HttpResponseMessage?> Save(ProductCategory data)
        {
            return await this.http.PostAsJsonAsync<ProductCategory>(apiLink, data);
        }
        public async Task<HttpResponseMessage?> Update(ProductCategory data)
        {
            return await this.http.PutAsJsonAsync<ProductCategory>(apiLink + $"/{data.ProductCategoryID}", data);
        }

        public async Task<HttpResponseMessage?> Delete(int id)
        {
            return await this.http.DeleteAsync(apiLink + $"/{id}");
        }
    }
}
