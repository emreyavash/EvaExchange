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
        public string NormalizedShareName { get; set; }
        public double price { get; set; }
        public int Lot { get; set; }
    }
}
