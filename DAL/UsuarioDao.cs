using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsuarioDao
    {
        public UsuarioEntity GetUsuario(Int64 dni)
        {
            try
            {
                using(ContextDb context = new ContextDb())
                {
                    Usuario usuarioDb = context.Usuario.Where(usuario => usuario.DNI == dni).Select(usuario => usuario).FirstOrDefault();

                    UsuarioEntity usuarioEntity = UsuarioEntity.GetInstance(usuarioDb.DNI, usuarioDb.APELLIDO, usuarioDb.NOMBRE, usuarioDb.TELEFONO, usuarioDb.DIRECCION, usuarioDb.CIUDAD, usuarioDb.EMAIL);
                
                    return usuarioEntity;                
                }
            }
            catch { throw; }
        }


        public bool ValidarCredenciales(Int64 dni, string password)
        {
            try
            {
                using (ContextDb context = new ContextDb())
                {
                    if(context.Usuario.Where(usuario => usuario.DNI == dni && usuario.PASSWORD == password).Count() == 1) return true;
                    return false;
                }
            }
            catch { throw; }
        }
    }
}
