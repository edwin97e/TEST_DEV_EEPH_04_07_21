using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaFisicaController : ControllerBase
    {

        private readonly TokaDBContext _context;

        public PersonaFisicaController(TokaDBContext context)
        {
            _context = context;
        }

        //Metodo GET
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var Listpersonas = await _context.TbPersonasFisicas.ToListAsync();
                return Ok(Listpersonas);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        //Metodo GET by id 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            try
            {
                var persona = await _context.TbPersonasFisicas.FindAsync(id);
                if (persona != null)
                {
                    return Ok(persona);
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        //Metodo Post
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TbPersonasFisica persona)
        {
            try
            {
                _context.Add(persona);
                await _context.SaveChangesAsync();
                return Ok(persona);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Motodo Put
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TbPersonasFisica persona)
        {
            try
            {
                if (id != persona.IdPersonaFisica)
                {
                    return NotFound();
                }
                _context.Update(persona);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La persona a sido actualizada" });


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Metodo Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var persona = await _context.TbPersonasFisicas.FindAsync(id);
                if (persona == null)
                {
                    return NotFound();
                }
                _context.TbPersonasFisicas.Remove(persona);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Persona eliminda" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }




    }
}
