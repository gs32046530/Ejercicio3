using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Conexion.Entidades
{
    public class Usuario
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Puesto { get; set; }
        public string Clave { get; set; }
        public bool EstaActivo { get; set; }
        public string Edad { get; set; }
        public string Sexo { get; set; }

        public Usuario()
        {
        }

        public Usuario(string codigo, string nombre, string puesto, string clave, bool estaActivo, string edad, string sexo)
        {
            Codigo = codigo;
            Nombre = nombre;
            Puesto = puesto;
            Clave = clave;
            EstaActivo = estaActivo;
            Edad = edad;
            Sexo = sexo;
        }
    }
}
