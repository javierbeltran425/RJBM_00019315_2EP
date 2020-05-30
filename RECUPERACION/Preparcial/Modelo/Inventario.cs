using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preparcial.Modelo
{
    public class Inventario
    {
        // Cambio en el tipo de las variables idArticulo y stock a tipo int y la variable precio a tipo bool y agregando public a las variables
        public int idArticulo { get;}
        public string producto { get;}
        public string descripcion { get;}
        public decimal precio { get;}
        public int stock { get;}

        // Cambio en el tipo de las variables idArticulo y stock a tipo int y ña variable precio a tipo bool
        public Inventario(int idArticulo, string producto, string descripcion, decimal precio, int stock)
        {
            this.idArticulo = idArticulo;
            this.producto = producto;
            this.descripcion = descripcion;
            this.precio = precio;
            this.stock = stock;
        }
    }
}
