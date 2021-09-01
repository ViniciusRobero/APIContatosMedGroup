using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prova.Application.Service.Interfaces;
using Prova.Application.ViewModel;

namespace Prova.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : Controller
    {
        private readonly ILogger<ContatoController> _logger;
        private readonly IContatoService _contatoService;

        public ContatoController(ILogger<ContatoController> logger, IContatoService contatoService)
        {
            _logger = logger;
            _contatoService = contatoService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<ContatoViewModel>> GetAll()
        {
            return await _contatoService.GetAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _contatoService.GetById(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound("Registro não encontrado");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] ContatoViewModel viewModel)
        {
            var model = _contatoService.Incluir(viewModel).Result;

            if(model != null && String.IsNullOrEmpty(model.MsgErro))
                return Ok(model);
            else
                return BadRequest(model.MsgErro);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ContatoViewModel viewModel)
        {
            var model = await _contatoService.Alterar(viewModel);

            if (model != null && model.Valido)
                return Ok(model);
            else
                return BadRequest(model.MsgErro);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var result = await _contatoService.Excluir(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound(result.MsgErro);
        }

    }
}