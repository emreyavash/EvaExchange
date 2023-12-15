using Autofac;
using EvaExchange.Business.Services;
using EvaExchange.Infrastructure.Interface;
using EveExchange.DataAccess.Abstract;
using EveExchange.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaExchange.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>().SingleInstance();
            builder.RegisterType<UserDal>().As<IUserDal>().SingleInstance();
            
            builder.RegisterType<ShareService>().As<IShareService>().SingleInstance();
            builder.RegisterType<ShareDal>().As<IShareDal>().SingleInstance();
            
            builder.RegisterType<PortfolioService>().As<IPortfolioService>().SingleInstance();
            builder.RegisterType<PortfolioDal>().As<IPortfolioDal>().SingleInstance();
            
            builder.RegisterType<UserLotService>().As<IUserLotService>().SingleInstance();
            builder.RegisterType<UserLotDal>().As<IUserLotDal>().SingleInstance();

            builder.RegisterType<TradeService>().As<ITraderService>().SingleInstance();
            builder.RegisterType<TradeDal>().As<ITradeDal>().SingleInstance();
        }
    }
}
