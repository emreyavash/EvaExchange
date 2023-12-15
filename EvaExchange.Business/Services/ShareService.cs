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
    public class ShareService : IShareService
    {
        private readonly IShareDal _shareDal;

        public ShareService(IShareDal shareDal)
        {
            _shareDal = shareDal;
        }

        public async Task Add(Share entity)
        {
            entity.ShortShareName = ShortShareName(entity.ShareName);
            entity.CreatedAtTime = DateTime.Now;
            entity.UpdatedAtTime = DateTime.Now;
           await _shareDal.Add(entity);
        }

        public async Task Delete(Share entity)
        {
            await _shareDal.Delete(entity);
        }

        public async Task<Share> Get(int id)
        {
            var result = await _shareDal.Get(x=>x.Id == id);  
            return result;
        }

        public async Task<List<Share>> GetAll()
        {
            var result = await _shareDal.GetAll();
            return result;
        }

        public async Task Update(Share entity)
        {
           entity.UpdatedAtTime = DateTime.Now;
           await _shareDal.Update(entity);
        }
        private string ShortShareName(string shareName)
        {
            var shortNameArray = shareName.Split(" ").ToArray();
            var shortName="";
            if(shortNameArray.Length > 2)
            {
                foreach (var sn in shortNameArray)
                {
                    shortName += sn[0];
                    if (shortName.Length>2)
                    {
                        break;
                    }
                }
            }
            else if (shortNameArray.Length>1)
            {
                 shortName = shortNameArray[0].Substring(0, 2)+ shortNameArray[1].Substring(0, 1);
            }
            else
            {
                shortName = shortNameArray[0].Substring(0,3);
            }
            return shortName.ToUpper();
        }
    }
}
