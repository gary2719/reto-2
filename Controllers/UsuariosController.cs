using System.Text;
using Microsoft.AspNetCore.Mvc;
namespace reto_2.Controllers;

[ApiController]
[Route("[controller]")]
public class AutentificadorController : ControllerBase
{
    private readonly ILogger<AutentificadorController> logger;
    public AutentificadorController(ILogger<AutentificadorController> logger){

        this.logger = logger;
    }
    //Diccionario
    private static List<Usuarios> _usuariosList = new List<Usuarios>{
                new Usuarios {Nombre= "Gary", Cedula= "1718387796"},
                new Usuarios {Nombre= "Cesar Garcia", Cedula= "1717007000"}
            };


    [HttpGet(Name = "{id}")]

    public Usuarios AutentificarUsuarios([FromHeader] string id)

    {

        var user = _usuariosList.Where(x => x.Cedula == id).SingleOrDefault();



        if (user != null)

        {

            var plainTextBytes = Encoding.UTF8.GetBytes(user.Cedula);

            var cedulaBase64 = System.Convert.ToBase64String(plainTextBytes);



            return new Usuarios
            {

                Nombre = user.Nombre,

                Cedula = cedulaBase64

            };

        }

        throw new Exception("No se encuentra la cedula");



    }

    public class Usuarios
    {


        public string Nombre { get; set; }

        public string Cedula { get; set; }
    }
}
