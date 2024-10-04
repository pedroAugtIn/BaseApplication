using BaseApplication.Core.DomainObjects;
using BaseApplication.Domain.DTOs.Entries;
using BaseApplication.Domain.DTOs.Responses;
using BaseApplication.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BaseApplication.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var users = await userService.Get();
            return Ok(users);
        }
        catch (DomainException e)
        {
            var response = new BaseResponse<object>(false, null, null, new List<string> { e.Message });
            return NotFound(response);
        }
        catch (Exception e)
        {
            var response = new BaseResponse<object>(false, null, null,
                new List<string> { e.Message, e.InnerException?.Message! });
            return StatusCode(500, response);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var user = await userService.GetById(id);
            return Ok(user);
        }
        catch (DomainException e)
        {
            var response = new BaseResponse<object>(false, null, null, new List<string> { e.Message });
            return NotFound(response);
        }
        catch (Exception e)
        {
            var response = new BaseResponse<object>(false, null, null,
                new List<string> { e.Message, e.InnerException?.Message! });
            return StatusCode(500, response);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserEntry userEntry)
    {
        try
        {
            var createdUser = await userService.Create(userEntry);
            return StatusCode(201, createdUser);
        }
        catch (DomainException e)
        {
            var response = new BaseResponse<object>(false, null, null, new List<string> { e.Message });
            return BadRequest(response);
        }
        catch (Exception e)
        {
            var response = new BaseResponse<object>(false, null, null,
                new List<string> { e.Message, e.InnerException?.Message! });
            return StatusCode(500, response);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UserEntry userEntry)
    {
        try
        {
            var updatedUser = await userService.Update(id, userEntry);
            return Ok(updatedUser);
        }
        catch (DomainException e)
        {
            var response = new BaseResponse<object>(false, null, null, new List<string> { e.Message });
            return BadRequest(response);
        }
        catch (Exception e)
        {
            var response = new BaseResponse<object>(false, null, null,
                new List<string> { e.Message, e.InnerException?.Message! });
            return StatusCode(500, response);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        try
        {
            var deletedUser = await userService.Delete(id);
            return Ok(deletedUser);
        }
        catch (DomainException e)
        {
            var response = new BaseResponse<object>(false, null, null, new List<string> { e.Message });
            return NotFound(response);
        }
        catch (Exception e)
        {
            var response = new BaseResponse<object>(false, null, null,
                new List<string> { e.Message, e.InnerException?.Message! });
            return StatusCode(500, response);
        }
    }
}