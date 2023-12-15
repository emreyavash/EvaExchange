using EvaExchange.Business.Constants;
using EvaExchange.Business.Services;
using EvaExchange.Infrastructure.Interface;
using EveExchange.DataAccess.Entitiy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvaExchange.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfoliosController : ControllerBase
    {
        private readonly IPortfolioService _portfolioService;

        public PortfoliosController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }
        [HttpGet("PortfolioGetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result =await _portfolioService.GetAll();
            return Ok(result);
        }

        [HttpGet("GetPortfolioById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result =await _portfolioService.Get(id);
            return Ok(result);
        }
        [HttpGet("GetPortfolioByUserId")]
        public IActionResult GetPortfolioByUserId(int userId)
        {
            var result = _portfolioService.GetPortfolioByUserId(userId);
            return Ok(result);
        }
        [HttpPost("AddPortfolio")]
        public async Task<IActionResult> AddUPortfolio(Portfolio portfolio)
        {
            await _portfolioService.Add(portfolio);
            return Ok(Messages.Added);
        }
        [HttpPost("DeletePortfolio")]
        public async Task<IActionResult> DeletePortfolio(Portfolio portfolio)
        {
            await _portfolioService.Delete(portfolio);
            return Ok(Messages.Deleted);
        }
        [HttpPost("UpdatePortfolio")]
        public async Task<IActionResult> UpdatePortfolio(Portfolio portfolio)
        {
            await _portfolioService.Update(portfolio);
            return Ok(Messages.Updated);
        }
    }
}
