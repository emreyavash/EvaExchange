using EvaExchange.Business.Constants;
using EvaExchange.Infrastructure.Interface;
using EveExchange.DataAccess.Entitiy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvaExchange.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLotsController : ControllerBase
    {
        private readonly IUserLotService _userLotService;

        public UserLotsController(IUserLotService userLotService)
        {
            _userLotService = userLotService;
        }

        [HttpGet("UserLotGetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result =await _userLotService.GetAll();
            return Ok(result);
        }
        [HttpGet("GetUserLotById")]
        public async Task<IActionResult> Get(int id)
        {
            var result =await _userLotService.Get(id);
            return Ok(result);
        }
        [HttpGet("GetUserLotByUserId")]
        public async Task<IActionResult> GetUserLotByUserId(int userId)
        {
            var result =await _userLotService.Get(userId);
            return Ok(result);
        }
        [HttpPost("AddUserLot")]
        public async Task<IActionResult> AddUserLot(UserLot userLot)
        {
            await _userLotService.Add(userLot);
            return Ok(Messages.Added);
        }
        [HttpPost("DeleteUserLot")]
        public async Task<IActionResult> DeleteUserLot(UserLot userLot)
        {
            await _userLotService.Delete(userLot);
            return Ok(Messages.Deleted);
        }
        [HttpPost("UpdateUserLot")]
        public async Task<IActionResult> UpdateUserLot(UserLot userLot)
        {
            await _userLotService.Update(userLot);
            return Ok(Messages.Updated);
        }
    }
}
