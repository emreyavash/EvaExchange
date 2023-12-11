using EveExchange.DataAccess.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveExchange.DataAccess.Abstract
{
    public interface IEntityDal<T> where T : class,new()
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T Get(int id);
        List<T> GetAll();
    }
}
