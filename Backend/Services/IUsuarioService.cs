﻿using Backend.Models.Request;
using Backend.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public interface IUsuarioService
    {
        UsuarioResponse Auth(AuthRequest model);
    }
}
