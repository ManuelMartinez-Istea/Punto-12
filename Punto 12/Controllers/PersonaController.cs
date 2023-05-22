using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Punto_12.Contexto;
using Punto_12.Models;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Punto_12.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IsteaContext _contexto;
        public PersonaController(IsteaContext isteaContext)
        {
            _contexto = isteaContext;
        }

        [HttpGet]
        public IEnumerable<Persona> Get()
        {
            return _contexto.Personas.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Persona> Get(int id)
        {
            Persona persona = _contexto.Personas.FirstOrDefault(x => x.Id == id);
            if (persona == null)
            {
                return NotFound();
            }
            return persona;
        }

        [HttpPost]
        public ActionResult<Persona> Post([FromBody] Persona value)
        {
            _contexto.Personas.Add(value);
            _contexto.SaveChanges();

            return value;     
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Persona value)
        {
            if (id != value.Id)
            {
                return BadRequest();
            }
            _contexto.Entry(value).State = EntityState.Modified;
            _contexto.SaveChanges();
            return Ok();

        }

        [HttpDelete("{id}")]
        public ActionResult<Persona> Delete(int id)
        {
            Persona persona = _contexto.Personas.FirstOrDefault(a => a.Id == id);

            if (persona == null)
            {
                return NotFound();
            }
            _contexto.Personas.Remove(persona);
            _contexto.SaveChanges();
            return persona;
        }
    }
}
