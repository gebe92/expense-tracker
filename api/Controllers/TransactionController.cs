using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.TransactionDetails;
using api.Helpers;
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
        public async Task<IActionResult> GetAll([FromQuery] TransQueryObject query)
        {
            var trans = await _transRepo.GetAllAsync(query);
            var transDto = trans.Select(t => t.GetTransDto());

            return Ok(transDto);
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

        [HttpGet("user/{userId:int}")]
        public async Task<IActionResult> GetByUserId([FromRoute] int userId, [FromQuery] TransQueryObject query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trans = await _transRepo.GetByUserIdAsync(userId, query);

            if (trans == null)
            {
                return NotFound();
            }

            var transDto = trans.Select(t => t.GetTransDto());

            return Ok(transDto);
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

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTransDto transDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var trans = await _transRepo.UpdateAsync(id, transDto);

            if (trans == null)
            {
                return NotFound();
            }

            return Ok(trans.GetTransDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var trans = await _transRepo.DeleteAsync(id);

            if (trans == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}