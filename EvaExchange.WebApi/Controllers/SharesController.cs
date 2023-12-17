using EvaExchange.Business.Constants;
using EvaExchange.Infrastructure.Interface;
using EveExchange.DataAccess.Entitiy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvaExchange.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharesController : ControllerBase
    {
        private readonly IShareService _shareService;

        public SharesController(IShareService shareService)
        {
            _shareService = shareService;
        }
        [HttpGet("ShareGetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _shareService.GetAll();
            return Ok(result);
        }
        [HttpGet("GetShareById")]
        public async Task<IActionResult> Get(int id)
        {
            var result =await _shareService.Get(id);
            return Ok(result);
        }
        [HttpPost("AddShare")]
        public async Task<IActionResult> AddShare(Share share)
        {
            await _shareService.Add(share);
            return Ok(Messages.Added);
        }
        [HttpPost("DeleteShare")]
        public async Task<IActionResult> DeleteShare(Share share) 
        {
            await _shareService.Delete(share);
            return Ok(Messages.Deleted);
        }
        [HttpPost("UpdateShare")]
        public async Task<IActionResult> UpdateShare(Share share) 
        {
            await _shareService.Update(share);
            return Ok(Messages.Updated);
        }
        [HttpPost("UpdateShareDeneme")]
        public async Task<IActionResult> UpdateShareDeneme(int id)
        {
            await _shareService.UpdateSharePrice(id);
            return Ok(Messages.Updated);
        }
    }
}
