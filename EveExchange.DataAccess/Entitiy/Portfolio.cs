using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveExchange.DataAccess.Entitiy
{
    public class Portfolio:IEntity
    {
        public int UserId { get; set; }
        public double TotalBalance { get; set; }
        public double TotalShareBalance { get; set; }
    }
}
