using EveExchange.DataAccess.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EveExchange.DataAccess.Abstract
{
    public interface IEntityDal<T> where T : class,new()
    {
        Task Add(T entity);
        Task Delete(T entity);
        Task Update(T entity);
        Task<T> Get(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null);
    }
}
