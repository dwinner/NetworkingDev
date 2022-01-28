using System;
using System.Dynamic;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hosting;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestableSignalrApp.Model;

namespace TestableSignalrApp.Tests.SignalR
{
    [TestClass]
    public class BroadcasterHubTests
    {
        // Helper method

        private Broadcaster GetConfiguredHub(IDomain domain = null, string connId = null, string host = null)
        {
            domain = domain ?? new Domain(new Calculator());
            var hub = new Broadcaster(domain);
            connId = connId ?? "1234";
            host = host ?? "myhost";

            // Setup headers
            var mockRequest = new Mock<IRequest>();
            var mockHeaders = new Mock<INameValueCollection>();
            mockHeaders.Setup(h => h["host"]).Returns(host);
            mockRequest.Setup(r => r.Headers).Returns(mockHeaders.Object);

            // Setup user
            var identity = new GenericPrincipal(new GenericIdentity("jmaguilar"), new[] { "admin" });
            mockRequest.Setup(r => r.User).Returns(identity);

            // Setup context & connection id
            hub.Context = new HubCallerContext(mockRequest.Object, connId);

            return hub;

        }


        [TestMethod]
        public void PrivateMessage_Sends_A_Private_Mesage()
        {
            // Arrange
            var hub = GetConfiguredHub(connId: "1234");
            var destinationId = "666";
            var user = hub.Context.User.Identity.Name;
            var text = "Hi there!";


            var mockClients = new Mock<IHubCallerConnectionContext>();
            Message messageSent = null;

            dynamic client = new ExpandoObject();
            client.PrivateMessage = new Func<Message, Task>((Message data) =>
            {
                messageSent = data;
                return Task.FromResult(true);
            });

            mockClients.Setup(c => c.Client(destinationId))
                       .Returns((ExpandoObject)client);
            hub.Clients = mockClients.Object;

            // Act
            hub.PrivateMessage(destinationId, text).Wait();

            // Assert
            Assert.IsNotNull(messageSent, "Message not sent");
            Assert.AreEqual(user, messageSent.Sender);
            Assert.AreEqual(text, messageSent.Text);
        }

        // Client operations (helper interface)
        public interface IClientOperations
        {
            Task PrivateMessage(Message msg);
        }

        [TestMethod]
        public void PrivateMessage_Sends_A_Private_Mesage_With_Interface()
        {
            // Arrange
            var hub = GetConfiguredHub();
            var destinationId = "666";
            var user = hub.Context.User.Identity.Name;
            var text = "Hi there!";
            Message messageSent = null;

            var mockClients = new Mock<IHubCallerConnectionContext>();
            var mockClientOperations = new Mock<IClientOperations>();
            mockClientOperations
                .Setup(c => c.PrivateMessage(It.IsAny<Message>()))
                .Returns(Task.FromResult(true))
                .Callback<Message>(msg =>
                                    {
                                        messageSent = msg;
                                    });

            mockClients.Setup(c => c.Client(destinationId))
                       .Returns(mockClientOperations.Object);
            hub.Clients = mockClients.Object;

            // Act
            hub.PrivateMessage(destinationId, "Hi there!").Wait();

            // Assert
            Assert.IsNotNull(messageSent, "Message not sent");
            Assert.AreEqual(user, messageSent.Sender);
            Assert.AreEqual(text, messageSent.Text);
        }


        [TestMethod]
        public void On_Connected_sends_a_broadcast_with_information_about_the_new_connection()
        {
            // Arrange
            var hub = GetConfiguredHub(connId:"8888", host: "myhost");
            var expectedMessage = "New connection 8888 at myhost";

            var clientMethodInvoked = false;
            var messageSent = "";

            dynamic all = new ExpandoObject();
            all.Message = new Func<string, Task>((string message) =>
            {
                clientMethodInvoked = true;
                messageSent = message;
                return Task.FromResult(true);
            });

            var mockClients = new Mock<IHubCallerConnectionContext>();
            mockClients.Setup(c => c.All).Returns((ExpandoObject)all);
            hub.Clients = mockClients.Object;

            // 2) ACT
            hub.OnConnected().Wait();

            // 3) ASSERT 
            Assert.IsTrue(clientMethodInvoked, "No client methods invoked.");
            Assert.AreEqual(expectedMessage, messageSent);
        }

        [TestMethod]
        public void GetNumer_Returns_The_Number_Obtained_From_The_Domain()
        {
            // Arrange
            var inputNumber = 8;
            var expected = 99;
            var mockDomain = new Mock<IDomain>();
            mockDomain.Setup(d => d.GetNumber(inputNumber)).Returns(expected).Verifiable();
            var hub = GetConfiguredHub(mockDomain.Object);

            // Act
            var result = hub.GetNumber(8);

            // Assert
            Assert.AreEqual(expected, result);
            mockDomain.Verify();
        }
    }
}
