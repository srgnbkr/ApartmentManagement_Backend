using Application.Features.Blocks.Commands.CreateBlock;
using Application.Features.Blocks.Queries.GetListBlock;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Base;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockController : BaseController
    {
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var query = new GetListBlockQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateBlockCommand request)
        {
            var result = await Mediator.Send(request);
            return Created("", result); 
        }
    }
}
