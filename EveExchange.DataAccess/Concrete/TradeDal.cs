using EveExchange.DataAccess.Abstract;
using EveExchange.DataAccess.Entitiy;
using EveExchange.DataAccess.EvaExchangeDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveExchange.DataAccess.Concrete
{
    public class TradeDal : GenericDal<Trade,EvaExchangeContext>,ITradeDal
    {
    }
}
