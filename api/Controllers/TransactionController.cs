using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.TransactionDetails;
using api.Interface;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/trans")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionDetailsRepository _transRepo;

        public TransactionController(ITransactionDetailsRepository transRepo)
        {
            _transRepo = transRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var trans = await _transRepo.GetAllAsync();

            return Ok(trans);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trans = await _transRepo.GetByIdAsync(id);

            if (trans == null)
            {
                return NotFound();
            }

            return Ok(trans.GetTransDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTransDto transDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transModel = transDto.CreateTransDto();
            await _transRepo.CreateAsync(transModel);
            return CreatedAtAction(nameof(GetById), new { id = transModel.transID }, transModel.GetTransDto());
        }
    }
}