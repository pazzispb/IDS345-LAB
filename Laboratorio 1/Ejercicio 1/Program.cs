/* Autor: Pazzis Paulino
   Laboratorio 1. Ejercicio 1.
   Mandato: Crear una clase con propiedades. Instanciar la clase en un objeto. 
            Asignarle valores Mostrar los valores de las propiedades del objeto 
            por la pantalla consola.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ejercicio_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A continuacion, ingrese uno a uno los datos del producto: ");
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Precio: ");
            double precio = Convert.ToDouble(Console.ReadLine());
            Console.Write("Descripcion: ");
            string descripcion = Console.ReadLine();
            Console.Write("Stock: ");
            int stock = Convert.ToInt32(Console.ReadLine());
            Console.Write("ITBIS: ");
            double itbis = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();
            //Instanciacion del objeto de la clase Producto
            Producto producto = new Producto(nombre, precio, descripcion, stock, itbis);
            
            
            Console.WriteLine(producto.RetornarDatos());
            

        }
    }
}
