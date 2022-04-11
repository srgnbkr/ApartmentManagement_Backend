using Application.Features.Users.Commands.UpdateUser;
using Application.Features.Users.Commands.UpdateUserFromAuth;
using Application.Features.Users.Queries.GetUserList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Base;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var query = new GetUserListDtoQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand updateUserCommand)
        {
            var result = await Mediator.Send(updateUserCommand);
            return Created("", result);
        }

        [HttpPut("updateFromAuth")]
        public async Task<IActionResult> UpdateFromAuth([FromBody] UpdateUserFromAuthCommand updateUserFromAuthCommand)
        {
            
            var result = await Mediator.Send(updateUserFromAuthCommand);
            return Created("", result);
        }
    }
}
