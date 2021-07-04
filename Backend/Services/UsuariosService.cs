using Backend.Models;
using Backend.Models.Common;
using Backend.Models.Request;
using Backend.Models.Response;
using Backend.Tools;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class UsuariosService : IUsuarioService
    {
        private readonly AppSettingsClass _appSettings;

        public UsuariosService(IOptions<AppSettingsClass> appSettings) {
            _appSettings = appSettings.Value;
        }

        public UsuarioResponse Auth(AuthRequest model)
        {
            UsuarioResponse usuarioreponse = new UsuarioResponse();
            using (var db = new TokaDBContext()) 
            {
                string pass = EncryptClass.GetSHA256(model.Password);

                var usuario = db.TbUsuarios.Where(d => d.Email == model.Email &&
                                                  d.Password == pass).FirstOrDefault();

                if (usuario == null) {
                    usuarioreponse.Email = null;
                }
                usuarioreponse.Email = usuario.Email;
                //usuarioreponse.Token = GetToken(usuario);
            }
            return usuarioreponse;
        }

        private string GetToken(TbUsuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var llave = Encoding.ASCII.GetBytes(_appSettings.Secreto);
            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                        new Claim(ClaimTypes.Email, usuario.Email)
                    }
                    ),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = 
                new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
          };
            var token = tokenHandler.CreateToken(TokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

    }
}
