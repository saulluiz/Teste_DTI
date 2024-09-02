using Estrutura_Base.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using Estrutura_Base.Interfaces;
using Estrutura_Base.Dto;
namespace Estrutura_Base.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImpostoController : ControllerBase
    {
        private readonly IImpostoDeRendaService _service;
        public ImpostoController(IImpostoDeRendaService service)
        {
            _service = service;
        }

        [HttpPost("calcular")]
        public ActionResult GetIR([FromBody] IncomeDto income)
        {
            float result = _service.CalculateIR(income.renda);
            return Ok(new TaxDto { imposto = result });
        }
    }
}



