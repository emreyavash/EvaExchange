using EveExchange.DataAccess.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaExchange.Infrastructure.Interface
{
    public interface ITraderService
    {
        Task<bool> Buy(Trade trade);
        Task<bool> Sell(Trade trade);
    }
}
