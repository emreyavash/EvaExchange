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
    public class TradeService : ITraderService
    {
        private readonly IUserDal _userDal;
        private readonly IPortfolioDal _portfolioDal;
        private readonly IShareDal _shareDal;
        private readonly IUserLotDal _userLotDal;
        private readonly ITradeDal _tradeDal;
        public TradeService(IUserDal userDal, IPortfolioDal portfolioDal, IShareDal shareDal, IUserLotDal userLotDal, ITradeDal tradeDal)
        {
            _userDal = userDal;
            _portfolioDal = portfolioDal;
            _shareDal = shareDal;
            _userLotDal = userLotDal;
            _tradeDal = tradeDal;
        }

        public async Task<bool> Buy(Trade trade)
        {
            var portfolio = await _portfolioDal.Get(x=>x.UserId == trade.UserId);
            var share = await _shareDal.Get(x => x.Id == trade.ShareId);
            var userLot = await _userLotDal.Get(x => x.UserId == trade.UserId && x.ShareId == trade.ShareId);
            var checkUser = CheckUserExist(trade.UserId);
            if (!checkUser)
            {
                return false;
            }
            if ((portfolio.TotalBalance - (share.Price * trade.Lot)) < 0)
            {
                return false;
            }
            var portfolioUpdate = new Portfolio
            {
                Id = portfolio.Id,
                UserId = trade.UserId,
                TotalBalance = portfolio.TotalBalance - share.Price * trade.Lot
            };
         
            if(trade.Lot>share.Lot)
            {
                return false;
            }
            var shareUpdate = new Share
            {
                Lot =share.Lot -trade.Lot,
                Id = share.Id,
                Price = share.Price,
                ShareName = share.ShareName,
                ShortShareName = share.ShortShareName
                
            };
            if (userLot == null)
            {
                var userLotCreate = new UserLot
                {
                    ShareId = share.Id,
                    UserId = trade.UserId,
                    TotalNumberOfShare = trade.Lot,

                };
                await _userLotDal.Add(userLotCreate);
            }
            else
            {
                var userLotUpdate = new UserLot
                {
                    Id = userLot.Id,
                    ShareId = share.Id,
                    UserId = trade.UserId,
                    TotalNumberOfShare = userLot.TotalNumberOfShare + trade.Lot,

                };
                await _userLotDal.Update(userLotUpdate);
            }
            await _portfolioDal.Update(portfolioUpdate);
            await _shareDal.Update(shareUpdate);
            trade.BuyOrSell = true;
            await _tradeDal.Add(trade);
            return true;
        }

        public async Task<bool> Sell(Trade trade)
        {
            var portfolio = await _portfolioDal.Get(x => x.UserId == trade.UserId);
            var share = await _shareDal.Get(x => x.Id == trade.ShareId);
            var userLot = await _userLotDal.Get(x=>x.UserId == trade.UserId && x.ShareId == trade.ShareId);
            var checkUser = CheckUserExist(trade.UserId);
            if (!checkUser)
            {
                return false;
            }
            if( userLot == null||trade.Lot>userLot.TotalNumberOfShare || userLot.TotalNumberOfShare<0 )
            {
                return false;
            }
            var userLotUpdate = new UserLot
            {
                Id=userLot.Id,
                ShareId = share.Id,
                UserId = trade.UserId,
                TotalNumberOfShare = userLot.TotalNumberOfShare - trade.Lot,

            };
            await _userLotDal.Update(userLotUpdate);
           
            var shareUpdate = new Share
            {
                Lot = share.Lot + trade.Lot,
                Id = share.Id,
                Price = share.Price,
                ShareName = share.ShareName,
                ShortShareName = share.ShortShareName

            };
           
            var portfolioUpdate = new Portfolio
            {
                Id = portfolio.Id,
                UserId = trade.UserId,
                TotalBalance = portfolio.TotalBalance + share.Price * trade.Lot
            };
            await _portfolioDal.Update(portfolioUpdate);
            await _shareDal.Update(shareUpdate);
            trade.BuyOrSell = false;
            await _tradeDal.Add(trade);
            return true;
        }

        private bool CheckUserExist(int id)
        {
            var user = _userDal.Get(x => x.Id == id);
            if (user ==null)
            {
                return false;
            }
            return true;
        }
      
    }
}
