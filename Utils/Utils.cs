﻿using Ejemplo1.Models;

namespace Ejemplo1.Utils
{
    public class Utils
    {

        //static public List<Producto> ListaProductos = new List<Producto>()
        //{
        //    new Producto(1,"Producto 1", "Descripcion 1", 1),
        //    new Producto(2,"Producto 2", "Descripcion 2", 2),
        //    new Producto(3,"Producto 3", "Descripcion 3", 3),
        //    new Producto(4,"Producto 4", "Descripcion 4", 4),

        //};

        static public List<Producto> ListaProductos = new List<Producto>()
        {
            // Instancio un objeto con atributos tipados en vez de usar un constructor
            new Producto{

                IdProducto = 1,
                Nombre = "Producto 1",
                Descripcion = "Descripcion 1",
                Cantidad = 1

            },
            // Instancio un objeto con atributos tipados en vez de usar un constructor
            new Producto{

                IdProducto = 2,
                Nombre = "Producto 2",
                Descripcion = "Descripcion 2",
                Cantidad = 2

            }
        };
    }
}
