using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class UsuarioEntity
    {
        private UsuarioEntity(Int64 dni, string apellido, string nombre, string telefono, string direccion, string ciudad, string email)
        {
            this.dni = dni;
            this.apellido = apellido;
            this.nombre = nombre;
            this.telefono = telefono;
            this.direccion = direccion;
            this.ciudad = ciudad;
            this.email = email;
        }

        //ATRIBUTOS
        private Int64 dni;
        private string apellido;
        private string nombre;
        private string telefono;
        private string direccion;
        private string ciudad;
        private string email;
        private static UsuarioEntity instancia = null;


        //PROPIEDADES PUBLICAS
        public long Dni { get => dni; }
        public string Apellido { get => apellido; }
        public string Nombre { get => nombre; }
        public string Telefono { get => telefono; }
        public string Direccion { get => direccion; }
        public string Ciudad { get => ciudad; }
        public string Email { get => email; }


        //METODOS
        static UsuarioEntity GetInstance(Int64 dni, string apellido, string nombre, string telefono, string direccion, string ciudad, string email)
        {
            if (instancia == null)
            {
                return new UsuarioEntity(dni, apellido, nombre, telefono, direccion, ciudad, email);
            }
            else
                return instancia;
        }

        static UsuarioEntity GetInstance()
        {
            if (instancia != null) return instancia;
            else return null;
        }
    }
}
