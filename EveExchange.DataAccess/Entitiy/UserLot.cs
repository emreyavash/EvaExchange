using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveExchange.DataAccess.Entitiy
{
    public class UserLot:IEntity
    {
        public int UserId { get; set; }
        public int ShareId { get; set; }
        public int TotalNumberOfShare { get; set; }
        public double TotalBalanceOfShare { get; set; }
    }
}
