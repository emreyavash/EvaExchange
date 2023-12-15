using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveExchange.DataAccess.Entitiy
{
    public class Share : IEntity
    {
        public string ShareName { get; set; }
        public string ShortShareName { get; set; }
        public double Price { get; set; } 
        public int Lot { get; set; }
        public DateTime CreatedAtTime { get; set; }
        public DateTime UpdatedAtTime { get; set;}
    }
}
