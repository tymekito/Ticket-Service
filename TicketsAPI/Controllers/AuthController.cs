﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TicketsAPI.Entities;
using TicketsAPI.IServices;
using TicketsAPI.Models;

namespace TicketsAPI.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService service;
        public AuthController(IAuthService service)
        {
            this.service = service;
        }
        [HttpPost]
        public async Task<ActionResult> Login([FromForm] AuthLogin model)
        {        
            var responce = await service.AuthenticateUser(model.Login, model.Password);
            return Ok(responce);
        }
    }
}
