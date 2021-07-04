using System;
using System.Collections.Generic;

#nullable disable

namespace Backend.Models
{
    public partial class TbUsuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
    }
}
