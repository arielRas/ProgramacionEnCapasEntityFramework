using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business
{
    public  class UsuarioBusiness
    {
        private UsuarioDao usuarioDao = new UsuarioDao();


        public bool ValidarCredenciales(string dni, string password)
        {
            if (!Regex.IsMatch(dni, @"\d{8}")) throw new Exception("El campo DNI solo acepta valores numericos y debe tener 8 digitos");

            if (password == string.Empty || password == null) throw new Exception("El campo coontraseña no puede estar vacio");

            return usuarioDao.ValidarCredenciales(Convert.ToInt64(dni), password);
        }

        public void GetUsuario(Int64 dni)
        {
            usuarioDao.GetUsuario(Convert.ToInt64(dni));
        }

    }
}
