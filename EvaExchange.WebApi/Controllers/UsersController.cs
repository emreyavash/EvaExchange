using EvaExchange.Business.Constants;
using EvaExchange.Infrastructure.Interface;
using EveExchange.DataAccess.Entitiy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvaExchange.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("UserGetAll")]
        public async Task<IActionResult> GetAll() 
        {
            var result = await _userService.GetAll();
            return Ok(result);
        }

        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userService.Get(id);
            return Ok(result);
        }
        [HttpGet("GetUserByUsername")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            var result = await _userService.GetUserByUsername(username);
            return Ok(result);
        }
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(User user)
        {
            await _userService.Add(user);
            return Ok(Messages.Added);
        }
        [HttpPost("DeleteUser")]
        public async Task<IActionResult> DeleteUser(User user)
        {
            await _userService.Delete(user);
            return Ok(Messages.Deleted);
        }
        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser(User user)
        {
            await _userService.Update(user);
            return Ok(Messages.Updated);
        }
    }
}
