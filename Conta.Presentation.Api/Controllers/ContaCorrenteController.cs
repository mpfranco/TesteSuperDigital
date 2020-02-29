using System;
using Conta.Presentation.Api.Extensions;
using Conta.Application.Interfaces;
using Conta.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Conta.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaCorrenteController : ControllerBase
    {
        private readonly IApplicationContaCorrente app;
        public ContaCorrenteController(IApplicationContaCorrente _app)
        {
            app = _app;
        }
        
        [ClaimsAuthorize("ContaCorrente", "Listar")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(app.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ClaimsAuthorize("ContaCorrente", "Adicionar")]
        [HttpPost]
        public IActionResult Post([FromBody] ContaCorrenteViewModel model)
        {
            try
            {
                return Ok(app.Add(model));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}