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
    public class UserLotService : IUserLotService
    {
        private readonly IUserLotDal _userLotDal;

        public UserLotService(IUserLotDal userLotDal)
        {
            _userLotDal = userLotDal;
        }

        public async Task Add(UserLot entity)
        {
          await _userLotDal.Add(entity);
        }

        public async Task Delete(UserLot entity)
        {
            await _userLotDal.Delete(entity);
        }

        public async Task<UserLot> Get(int id)
        {
            var result = await _userLotDal.Get(x => x.Id == id);
            return result;
        }

        public  async Task<List<UserLot>> GetAll()
        {
            var result = await _userLotDal.GetAll();
            return result;
        }

        public async Task<UserLot> GetUserLotByUserId(int userId)
        {
            var result = await _userLotDal.Get(x => x.UserId == userId);
            return result;
        }

        public async Task Update(UserLot entity)
        {
           await _userLotDal.Update(entity);
        }
    }
}
