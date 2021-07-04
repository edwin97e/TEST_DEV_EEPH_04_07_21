using Backend.Models.Request;
using Backend.Models.Response;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService) {
            _usuarioService = usuarioService;
        }


        [HttpPost("login")]
        public IActionResult Autentication([FromBody] AuthRequest model )
        {
           
                Respuesta respuesta = new Respuesta();
                var usuarioresponse = _usuarioService.Auth(model);
                
                if (usuarioresponse == null) {
                    respuesta.Exito = 0;
                    respuesta.Mensaje = "Usuario o contraseña incorrecta";
                    return BadRequest(respuesta);
                }
                respuesta.Exito = 1;
                respuesta.Data = usuarioresponse;
                return Ok(respuesta);
            
        }


    }
}
