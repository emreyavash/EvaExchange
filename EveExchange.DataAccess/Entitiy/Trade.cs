using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveExchange.DataAccess.Entitiy
{
    public class Trade  : IEntity
    {
        public int UserId { get; set; }
        public int ShareId { get; set; }
        public int Lot { get; set; }
        public bool BuyOrSell { get; set; }
        public DateTime CreateAtTime { get; set; }
    }
}
