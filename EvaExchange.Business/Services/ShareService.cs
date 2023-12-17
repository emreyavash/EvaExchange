using EvaExchange.Infrastructure.Interface;
using EveExchange.DataAccess.Abstract;
using EveExchange.DataAccess.Concrete;
using EveExchange.DataAccess.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace EvaExchange.Business.Services
{
    public class ShareService : IShareService
    {
        private readonly IShareDal _shareDal;
        private readonly ITradeDal _tradeDal;
        private readonly IPortfolioDal _portfolioDal;
        private readonly IUserLotDal _userLotDal;

        public ShareService(IShareDal shareDal, ITradeDal tradeDal, IPortfolioDal portfolioDal, IUserLotDal userLotDal)
        {
            _shareDal = shareDal;
            _tradeDal = tradeDal;
            _portfolioDal = portfolioDal;
            _userLotDal = userLotDal;
        }

        public async Task Add(Share entity)
        {
            entity.ShortShareName = ShortShareName(entity.ShareName);
            entity.BeforePrice = entity.Price;
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
            entity.CreatedAtTime = entity.CreatedAtTime;
           await _shareDal.Update(entity);
        }
        public async Task UpdateSharePrice(int shareId)
        {
            var share = await _shareDal.Get(x=>x.Id == shareId);


            if(share != null)
            {
               
                    var rate = await Rate(share.Id);
                    share.BeforePrice = share.Price;
                    share.Price = Math.Round(share.Price + ((share.Price * rate) / share.Lot), 2, MidpointRounding.AwayFromZero);
                    await UserLotUpdate(share);
                    await Update(share);
              
                
                
            }
            

        }
        private async Task UserLotUpdate(Share share)
        {
            var userLots = await _userLotDal.GetAll(x=>x.ShareId == share.Id);

            foreach (var user in userLots)
            {
                user.TotalBalanceOfShare = Math.Round(user.TotalNumberOfShare * share.Price, 2, MidpointRounding.AwayFromZero);
                if (user.TotalNumberOfShare !=0)
                {
                await PortfolioUpdate(user,share);

                }

                await _userLotDal.Update(user);

            }

        }
        private async Task PortfolioUpdate(UserLot userLot,Share share)
        {
            var portfolio = await _portfolioDal.Get(x=>x.UserId == userLot.UserId);

           
            portfolio.TotalShareBalance = Math.Round(portfolio.TotalShareBalance +(userLot.TotalNumberOfShare * share.Price -share.BeforePrice*userLot.TotalNumberOfShare  ), 2, MidpointRounding.AwayFromZero);
            
            await _portfolioDal.Update(portfolio);

        }
        private async Task<double> Rate(int shareId)
        {
            var share = await _shareDal.Get(x => x.Id == shareId);
            TimeSpan shareTime = DateTime.Now - share.UpdatedAtTime;
            TimeSpan shareTimerThread = TimeSpan.FromMinutes(1);
            var trades = await _tradeDal.GetAll(x => x.ShareId == share.Id);
            int totalLotForBuy = 0;
            int totalBuyCount = 0;
            int totalSellCount = 0;
            int totalLotForSell = 0;
   

            foreach (var trade in trades)
            {
                DateTime startDate = trade.CreateAtTime;
                TimeSpan timerspan = DateTime.Now - startDate;
                TimeSpan timerThread = TimeSpan.FromMinutes(1);
                if(timerspan< timerThread && shareTime < shareTimerThread)
                {
                    if (trade.BuyOrSell)
                    {
                        totalLotForBuy += trade.Lot;
                        totalBuyCount += 1;
                    }
                    else
                    {
                        totalLotForSell += trade.Lot;
                        totalSellCount += 1;


                    }
                }
               
            }
            int totalBuyRate = totalBuyCount * totalLotForBuy;
            int totalSellRate = totalSellCount * totalLotForSell;
            if (totalLotForBuy == 0)
            {
                return -totalSellRate;
            }
            else if (totalLotForSell == 0)
            {
                return totalBuyRate;
            }
            else if(totalLotForBuy ==0 && totalLotForSell == 0)
            {
                return 0;
            }
            else if (totalLotForSell > totalLotForBuy)
            {
                return -(totalBuyRate / totalSellRate);
            }
            return totalBuyRate / totalSellRate;

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
