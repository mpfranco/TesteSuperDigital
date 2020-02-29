using System;
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
    public class LancamentoController : ControllerBase
    {
        private readonly IApplicationLancamento app;        
        public LancamentoController(IApplicationLancamento _app)
        {
            app = _app;
        }

        
        [ClaimsAuthorize("Lancamento", "Listar")]
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

        [ClaimsAuthorize("Lancamento", "Adicionar")]
        [HttpPost]
        public IActionResult Post([FromBody] LancamentoViewModel model)
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