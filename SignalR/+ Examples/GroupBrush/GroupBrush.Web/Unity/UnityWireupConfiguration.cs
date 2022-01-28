using GroupBrush.BusinessLogic.Canvases;
using GroupBrush.BusinessLogic.Storage;
using GroupBrush.BusinessLogic.Users;
using GroupBrush.DataLayer.Canvases;
using GroupBrush.DataLayer.Users;
using GroupBrush.Entity;
using Microsoft.Azure;
using Microsoft.Practices.Unity;

namespace GroupBrush.Web.Unity
{
   public static class UnityWireupConfiguration
   {
      public static void WireUp(UnityDependencyResolver dependencyResolver)
      {
         var groupBrushConnectionString = CloudConfigurationManager.GetSetting("GroupBrushDb");
         dependencyResolver.RegisterType<IUserService, UserService>(new ContainerControlledLifetimeManager());
         dependencyResolver.RegisterType<ICanvasService, CanvasService>();
         dependencyResolver.RegisterType<ICanvasRoomService, CanvasRoomService>();
         dependencyResolver.Register(typeof(IGetUserNameFromIdData),
            () => new GetUserNameFromIdData(groupBrushConnectionString));
         dependencyResolver.Register(typeof(IGetCanvasDescriptionData),
            () => new GetCanvasDescriptionData(groupBrushConnectionString));
         dependencyResolver.Register(typeof(ICreateUserData),
            () => new CreateUserData(groupBrushConnectionString));
         dependencyResolver.Register(typeof(IValidateUserData),
            () => new ValidateUserData(groupBrushConnectionString));
         dependencyResolver.Register(typeof(ICreateCanvasData),
            () => new CreateCanvasData(groupBrushConnectionString));
         dependencyResolver.Register(typeof(ILookUpCanvasData),
            () => new LookUpCanvasData(groupBrushConnectionString));

         var groupBrushRedisHostname = CloudConfigurationManager.GetSetting("GroupBrushRedisHostname");
         var groupBrushRedisPassword = CloudConfigurationManager.GetSetting("GroupBrushRedisPassword");
         var strUseRedis = CloudConfigurationManager.GetSetting("UseRedis") ?? "false";
         var useRedis = bool.Parse(strUseRedis);
         var redisConfiguration = new RedisConfiguration(groupBrushRedisHostname, groupBrushRedisPassword, useRedis);
         dependencyResolver.RegisterInstance(redisConfiguration);

         if (useRedis)
         {
            dependencyResolver.RegisterType<IMemStorage, RedisStorage>(new ContainerControlledLifetimeManager(),
               new InjectionConstructor(redisConfiguration));
         }
         else
         {
            dependencyResolver.RegisterType<IMemStorage, MemoryStorage>(new ContainerControlledLifetimeManager());
         }
      }
   }
}