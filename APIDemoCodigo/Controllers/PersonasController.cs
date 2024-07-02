using APIDemoCodigo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace APIDemoCodigo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        public static List<Persona> personas = new List<Persona>();

        [HttpGet]
        public List<Persona> Listar()
        {                
            return personas;
        }

        [HttpGet]
        public Persona BuscarPorId(int Id)
        {
            Persona persona = personas.Where(x => x.Id == Id).FirstOrDefault();
           
            return persona;
        }

        [HttpPost]
        public void Insertar( [FromBody] Persona persona)
        {
            personas.Add(persona);
        }

        [HttpPut]
        public void Actualizar([FromBody] Persona persona, int Id )
        {
            Persona personaActualizar = personas.Where(x => x.Id == Id).FirstOrDefault();
            personaActualizar.Nombres = persona.Nombres;
            personaActualizar.Apellidos = persona.Apellidos;

        }

        [HttpDelete]
        public void Eliminar(int Id)
        {
            Persona personaEliminar = personas.Where(x => x.Id == Id).FirstOrDefault();
            personas.Remove(personaEliminar);

        }

    }
}
