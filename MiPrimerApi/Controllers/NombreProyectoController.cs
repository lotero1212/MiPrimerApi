using Microsoft.AspNetCore.Mvc;

namespace MiPrimerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NombreProyectoController : ControllerBase
    {
        [HttpGet(Name = "GetProjectName")]
        public string GetProjectName()
        {
            return "Lucas Otero Proyecto Final C#";
        }
    }
}

