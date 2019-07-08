using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
   public class CD_Usuario
    {

        public UsuarioModel ChecarUsuario (UsuarioModel user)
        {
            using (var contexto = new BDProyectoMVCEntities())
            {
                int iExiste = contexto.Usuario.Where(u => u.Usuario1 == user.sUsuario &&
                u.Contraseña == user.sContraseña).Count();
                if(iExiste > 0)
                {
                    user = contexto.Usuario.Where(u => u.Usuario1 == user.sUsuario &&
                u.Contraseña == user.sContraseña).Select(usu => new UsuarioModel()
                {
                    sUsuario = usu.Usuario1,
                    sContraseña = usu.Contraseña,
                    sApp = usu.App,
                    sApm = usu.Apm,
                    sCorreo = usu.Correo,
                    sNombre = usu.Nombre,
                    dtFechaNacimiento = usu.FechaNacimiento                    
                    

                }).FirstOrDefault();
                }
            return user;
            }
                
        }
    }
}
