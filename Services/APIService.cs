using Ejemplo1.Models;
using Ejemplo1.Services;
using Newtonsoft.Json;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ejemplo1.API
{
    public class APIService : IServicio_API
    {
        private static string _baseURL;

        



        public APIService()
        {
            // Configuración de la URL base de la API a partir del archivo appsettings.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            _baseURL = builder.GetSection("ApiSettings:URL").Value;


        }

        public async Task<Producto> CreateProducto(Producto newProduct)
        {
            HttpClient httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(newProduct);

            var newProductJSON = new StringContent(json, Encoding.UTF8, "application/json");

            // Send a POST request to the API
            HttpResponseMessage response = await httpClient.PostAsync("http://localhost:5293/api/Producto", newProductJSON);

            // Asegura que la solicitud se haya realizado con éxito
            if (response.IsSuccessStatusCode)
            {
                // Lee el contenido de la respuesta como una cadena
                string content = await response.Content.ReadAsStringAsync();

                // Deserializa la cadena JSON en un objeto Producto
                Producto productoModificado = JsonConvert.DeserializeObject<Producto>(content);

                return productoModificado;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }

        }

        public async Task<string> DeleteProducto(int IdProducto)
        {
            HttpClient httpClient = new HttpClient();
            // Realiza una solicitud DELETE a la API para eliminar un producto por su ID
            HttpResponseMessage response = await httpClient.DeleteAsync($"http://localhost:5293/api/Producto/ {IdProducto}");

            // Asegura que la solicitud se haya realizado con éxito
            if (response.IsSuccessStatusCode)
            {
                // Lee el contenido de la respuesta como una cadena
                string mensaje = await response.Content.ReadAsStringAsync();

                return mensaje;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }

        }

        public async Task<List<Producto>> GetProducto()
        {
            HttpClient httpClient = new HttpClient();
            // Realiza una solicitud GET a la API para obtener la lista de productos
            HttpResponseMessage response = await httpClient.GetAsync("http://localhost:5293/api/Producto");

            // Asegura que la solicitud se haya realizado con éxito
            if (response.IsSuccessStatusCode)
            {
                // Lee el contenido de la respuesta como una cadena
                string content = await response.Content.ReadAsStringAsync();

                // Deserializa la cadena JSON en una lista de objetos Producto
                List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(content);

                return productos;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }

        }

        public async Task<Producto> GetProductoByID(int IdProducto)
        {
            HttpClient httpClient = new HttpClient();
            // Realiza una solicitud GET a la API para obtener un producto por su ID
            HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:5293/api/Producto/{IdProducto}");

            // Asegura que la solicitud se haya realizado con éxito
            if (response.IsSuccessStatusCode)
            {
                // Lee el contenido de la respuesta como una cadena
                string content = await response.Content.ReadAsStringAsync();

                // Deserializa la cadena JSON en un objeto Producto
                Producto productoEncontrado = JsonConvert.DeserializeObject<Producto>(content);

                return productoEncontrado;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }
        }

        public async Task<Producto> UpdateProducto(Producto newProduct, int IdProducto)
        {
            HttpClient httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(newProduct);

            var newProductJSON = new StringContent(json, Encoding.UTF8, "application/json");

            // Realiza una solicitud PUT a la API para actualizar un producto por su ID
            HttpResponseMessage response = await httpClient.PutAsync(_baseURL + "api/Producto/" + IdProducto, newProductJSON);

            // Asegura que la solicitud se haya realizado con éxito
            if (response.IsSuccessStatusCode)
            {
                // Lee el contenido de la respuesta como una cadena
                string content = await response.Content.ReadAsStringAsync();

                // Deserializa la cadena JSON en un objeto Producto
                Producto productoModificado = JsonConvert.DeserializeObject<Producto>(content);

                return productoModificado;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }
        }
    }
}
