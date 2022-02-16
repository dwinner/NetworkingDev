using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Emso.WebUi.Infrastructure.Ifaces;
using Emso.WebUi.ViewModels;
using EmsoHr.Entities;
using Moq;

namespace Emso.WebUi.Services.UnitTests.Utilities
{
   internal static class RssFeedFactory
   {
      private const int FeedCount = 20;
      private const int PageSize = 3;

      private static readonly string _NewsFeedEndpoint =
         (string) CommonEnvFactory.AppSettingsReader.GetValue("_NewsFeedEndpoint", typeof (string));

      public static readonly RssFeedViewModel[] FeedVms;
      private static readonly NewsFeed[] _Feeds;

      static RssFeedFactory()
      {
         AutoMapperConfig.ConfigureViewModelMapping();

         FeedVms = new RssFeedViewModel[FeedCount];
         for (var i = 0; i < FeedCount; i++)
         {
            FeedVms[i] = new RssFeedViewModel(i, string.Format("title{0}", i), string.Format("details{0}", i),
               string.Empty, DateTime.Now.AddMilliseconds(-i), false, string.Empty);
         }

         _Feeds = new NewsFeed[FeedCount];
         for (var i = 0; i < FeedCount; i++)
         {
            _Feeds[i] = Mapper.Map<NewsFeed>(FeedVms[i]);
         }
      }

      internal static IPagingConfiguration NewPagingMock
      {
         get
         {
            var pageMock = new Mock<IPagingConfiguration>();
            pageMock.Setup(pagingConfig => pagingConfig.PageSize)
               .Returns(PageSize);
            var pagingConfiguration = pageMock.Object;
            return pagingConfiguration;
         }
      }

      internal static IRssFeedSource NewFeedMock
      {
         get
         {
            var feedMock = new Mock<IRssFeedSource>();
            feedMock.Setup(source => source.GetAllNewsAsync()).Returns(Task.FromResult<IEnumerable<NewsFeed>>(_Feeds));
            var rssFeedSource = feedMock.Object;

            return rssFeedSource;
         }
      }

      internal static NewsFeedController NewFeedController(IRssFeedSource rssFeedSource,
         IPagingConfiguration pagingConfiguration, string methodRoute)
      {
         return new NewsFeedController(rssFeedSource, pagingConfiguration)
         {
            Configuration = new HttpConfiguration(),
            Request = new HttpRequestMessage
            {
               Method = HttpMethod.Post,
               RequestUri =
                  new Uri(
                     string.Format("{0}:{1}{2}{3}", CommonEnvFactory.TestHostAddress, CommonEnvFactory.TestPort,
                        _NewsFeedEndpoint, methodRoute))
            }
         };
      }
   }
}