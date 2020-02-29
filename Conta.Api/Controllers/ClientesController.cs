using System;
using System.Collections.Generic;
using Conta.Api.Extensions;
using Conta.Application.Interfaces;
using Conta.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Conta.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IApplicationCliente app;

        public ClientesController(IApplicationCliente _app)
        {
            app = _app;
        }

        [ClaimsAuthorize("Cliente", "Listar")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                return Ok(app.GetAll());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
      
        [ClaimsAuthorize("Cliente", "Adicionar")]
        [HttpPost]
        public IActionResult Post([FromBody] ClienteViewModel cliente)
        {
            try
            {
                return Ok(app.Add(cliente));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }             
    }
}
