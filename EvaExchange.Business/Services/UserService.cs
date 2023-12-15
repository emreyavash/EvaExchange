using EvaExchange.Infrastructure.Interface;
using EveExchange.DataAccess.Abstract;
using EveExchange.DataAccess.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaExchange.Business.Services
{
    
    public class UserService : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IPortfolioDal _portfolioDal;
        public UserService(IUserDal userDal, IPortfolioDal portfolioDal)
        {
            _userDal = userDal;
            _portfolioDal = portfolioDal;
        }

        public async Task Add(User entity)
        {
            await _userDal.Add(entity);
            var user =  GetUserByUsername(entity.Username);
            var portfolio = new Portfolio
            {
                UserId = entity.Id,
                TotalBalance = 1000,
            };
            await _portfolioDal.Add(portfolio);
        }

        public async Task Delete(User entity)
        {
           await _userDal.Delete(entity);
        }

        public async Task<User> Get(int id)
        {
            var result = await _userDal.Get(x=>x.Id ==id);
            return result;
        }

        public async Task<List<User>> GetAll()
        {
            var result = await _userDal.GetAll();
            return result;
        }

        public async Task<User> GetUserByUsername(string username)
        {
            var result = await _userDal.Get(x => x.Username == username);
            return result;
        }

        public async Task Update(User entity)
        {
            await _userDal.Update(entity);
        }
    }
}
