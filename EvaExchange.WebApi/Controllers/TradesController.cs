using EvaExchange.Business.Constants;
using EvaExchange.Infrastructure.Interface;
using EveExchange.DataAccess.Entitiy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvaExchange.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradesController : ControllerBase
    {
        private readonly ITraderService _tradeService;

        public TradesController(ITraderService tradeService)
        {
            _tradeService = tradeService;
        }
        [HttpPost("Buy")]
        public async Task<IActionResult> Buy(Trade trade)
        {
            var buy =await _tradeService.Buy(trade);
            if (!buy)
            {
                return BadRequest(Messages.FailedBuy);
            }
            return Ok(Messages.Buyed);
        }

        [HttpPost("Sell")]
        public async Task<IActionResult> Sell(Trade trade)
        {
            var sell = await _tradeService.Sell(trade);
            if (!sell)
            {
                return BadRequest(Messages.FailedSell);
            }
            return Ok(Messages.Selled);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int shareId)
        {
            var trade = await _tradeService.GettAll(shareId);
            return Ok(trade);
        }
    }
}
