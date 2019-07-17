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

        public int NuevoUsuario(UsuarioModel user)
        {
            using (var contexto = new BDProyectoMVCEntities())
            {
                var iExiste = contexto.Usuario.Where(u => u.Correo == user.sCorreo || u.Usuario1 == user.sUsuario).FirstOrDefault();
                if (iExiste != null)
                    return 0;
                var usuarioNuevo = new Usuario
                {
                    Usuario1 = user.sUsuario,
                    Contraseña = user.sContraseña,
                    App = user.sApp,
                    Apm = user.sApm,
                    Correo = user.sCorreo,
                    Nombre = user.sNombre,
                    FechaNacimiento = user.dtFechaNacimiento
                };
                contexto.Usuario.Add(usuarioNuevo);
                contexto.SaveChanges();
            }
            
            return 1;
        }
        
    }
}
