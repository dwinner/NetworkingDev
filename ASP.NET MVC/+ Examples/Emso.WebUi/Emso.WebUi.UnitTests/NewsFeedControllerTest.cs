using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Emso.WebUi.Services.UnitTests.Utilities;
using NUnit.Framework;

namespace Emso.WebUi.Services.UnitTests
{
   [TestFixture]
   public class NewsFeedControllerTest : IisTesterBase
   {      
      [OneTimeSetUp]
      protected void SetUpOnce()
      {
         Init();
      }

      [OneTimeTearDown]
      protected void TearDownOnce()
      {
         Destroy();
      }

      [Test]
      [TestCase(1)]
      [TestCase(2)]
      [TestCase(3)]
      [TestCase(4)]
      [TestCase(5)]
      public async Task GetAllTestAsync(int page)
      {
         string pageRoute = string.Format("/{0}", page);
         var rssFeedSource = RssFeedFactory.NewFeedMock;
         var pagingConfiguration = RssFeedFactory.NewPagingMock;
         var feedController = RssFeedFactory.NewFeedController(rssFeedSource, pagingConfiguration,
            string.Format("{0}{1}", "/all", pageRoute));

         var expected = RssFeedFactory.FeedVms.OrderByDescending(rssModel => rssModel.NewsDate)
               .Skip((page - 1)*pagingConfiguration.PageSize)
               .Take(pagingConfiguration.PageSize)
               .ToArray();
         var actual = (await feedController.GetAllAsync(page).ConfigureAwait(false)).ToArray();

         Assert.IsTrue(expected.Length == actual.Length);
         for (var i = 0; i < expected.Length; i++)
         {
            Assert.IsTrue(expected[i].Equals(actual[i]));
         }
      }

      [Test]
      public async Task GetNavigatorConfigTestAsync()
      {
         var rssFeedSource = RssFeedFactory.NewFeedMock;
         var pagingConfiguration = RssFeedFactory.NewPagingMock;
         var feedController = RssFeedFactory.NewFeedController(rssFeedSource, pagingConfiguration, "/navConfig");

         var newsFeeds = (await rssFeedSource.GetAllNewsAsync().ConfigureAwait(false)).ToArray();
         var expectedCount = newsFeeds.Length;
         var expectedPageSize = pagingConfiguration.PageSize;
         var navigationInfo = await feedController.GetNavigatorConfigAsync().ConfigureAwait(false);
         var actualCount = navigationInfo.TotalItemsCount;
         var actualPageSize = navigationInfo.ItemsPerPageCount;

         Assert.IsTrue(actualPageSize == expectedPageSize);
         Assert.IsTrue(actualCount == expectedCount);
      }

      [Test]
      public async Task GetNewsImageTestAsync()
      {
         var rssFeedSource = RssFeedFactory.NewFeedMock;
         var pagingConfiguration = RssFeedFactory.NewPagingMock;
         var feedController = RssFeedFactory.NewFeedController(rssFeedSource, pagingConfiguration, "/newsImage");
         var responseMessage = await feedController.GetNewsImageAsync(RssFeedFactory.FeedVms[0].FeedId).ConfigureAwait(false);

         Assert.IsTrue(responseMessage.StatusCode == HttpStatusCode.NotFound);
      }
   }
}