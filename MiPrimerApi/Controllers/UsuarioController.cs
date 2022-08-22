using Microsoft.AspNetCore.Mvc;
using MiPrimerApi.Controllers.DTOS;
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

        [HttpDelete]
        public void DeleteUsuario([FromBody] int id)
        {
            UsuarioHandler.DeleteUsuario(id);
        }

        [HttpPut]

        public bool UpdateUsuario([FromBody] PutUsuario usuario)
        {
            return UsuarioHandler.UpdateNombreUsuario(new Usuario
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre
            });
        }

        [HttpPost]

        public bool CreateUsuario([FromBody] PostUsuario usuario)
        {
            return UsuarioHandler.CreateUsuario(new Usuario
            {

                Apellido = usuario.Apellido,
                Contraseña = usuario.Contraseña,
                Mail = usuario.Mail,
                Nombre = usuario.Nombre,
                NombreUsuario = usuario.NombreUsuario
            });
        }

    }

}
