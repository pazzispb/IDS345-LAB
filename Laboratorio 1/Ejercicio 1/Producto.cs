using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_1
{
    internal class Producto
    {
        private string nombre;
        private double precio;
        private string descripcion;
        private int stock;
        private double itbis;

        public Producto(string nombre, double precio, string descripcion, int stock, double itbis)
        {
            this.nombre = nombre;
            this.precio = precio;
            this.descripcion = descripcion;
            this.stock = stock;
            this.itbis = itbis;
        }
        
        public string RetornarDatos()
        {
            string mensaje = "Los datos del producto son: \nNombre: " + nombre + "\nPrecio: " + precio + "\nDescripcion: " + descripcion + "\nStock: " + stock + "\nITBIS: " + itbis;
            return mensaje;
        }
    }
}
