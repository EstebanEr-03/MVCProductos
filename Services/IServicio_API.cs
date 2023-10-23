using Ejemplo1.Models;

namespace Ejemplo1.Services
{
    public interface IServicio_API
    {

        Task<List<Producto>> GetProducto();

        Task<Producto> CreateProducto(Producto newProduct);

        Task<Producto> GetProductoByID(int IdProducto);

        Task<Producto> UpdateProducto(Producto newProduct, int IdProducto);

        Task<string> DeleteProducto(int IdProducto);

    }
}
