using Microsoft.AspNetCore.Mvc;
using MiPrimerApi.Model;
using MiPrimerApi.Repository;

namespace MiPrimerApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet(Name = "GetUsuarios")]
        public List<Usuario> GetUsuarios()
        {
            return UsuarioHandler.GetUsuarios();
        }

        [HttpGet("{nombreUsuario}/{contraseña}")]

        public bool Login(string nombreUsuario, string contraseña)
        {
            Usuario usuario = UsuarioHandler.Login(nombreUsuario, contraseña);
            if(usuario.Id != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpGet ("{nombreUsuario}")]
        public List <Usuario> GetUsuariosByName(string nombreUsuario) 
        {
            return UsuarioHandler.GetUsuariosByName(nombreUsuario);
        }

    }

}
