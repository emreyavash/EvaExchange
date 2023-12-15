using EvaExchange.Infrastructure.Interface;
using EveExchange.DataAccess.Abstract;
using EveExchange.DataAccess.Concrete;
using EveExchange.DataAccess.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaExchange.Business.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioDal _portfolioDal;

        public PortfolioService(IPortfolioDal portfolioDal)
        {
            _portfolioDal = portfolioDal;
        }

        public async Task Add(Portfolio entity)
        {
           await _portfolioDal.Add(entity);
        }

        public async Task Delete(Portfolio entity)
        {
            await _portfolioDal.Delete(entity);
        }

        public async Task<Portfolio> Get(int id)
        {
            var result = await _portfolioDal.Get(x => x.Id == id);
            return result;
        }

        public async Task<List<Portfolio>> GetAll()
        {
            var result = await _portfolioDal.GetAll();
            return result;
        }

        public async Task<Portfolio> GetPortfolioByUserId(int userId)
        {
            var result = await _portfolioDal.Get(x => x.UserId == userId);
            return result;
        }

        public async Task Update(Portfolio entity)
        {
           await _portfolioDal.Update(entity);
        }
    }
}
