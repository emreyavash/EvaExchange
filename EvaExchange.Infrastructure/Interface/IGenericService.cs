using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaExchange.Infrastructure.Interface
{
    public interface IGenericService<TEntity> where TEntity : class,new()
    {
        Task Add(TEntity entity);
        Task Delete(TEntity entity);
        Task Update(TEntity entity);
        Task<TEntity> Get(int id);
        Task<List<TEntity>> GetAll();
    }
}
