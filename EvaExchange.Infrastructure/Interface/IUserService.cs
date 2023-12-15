using EveExchange.DataAccess.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaExchange.Infrastructure.Interface
{
    public interface IUserService : IGenericService<User>
    {
        Task<User> GetUserByUsername(string username);    
    }
}
