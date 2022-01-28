using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestableSignalrApp.Tests.SignalR
{
    [TestClass]
    public class EchoConnectionTests
    {
        public class TestableEchoConnection : EchoConnection
        {
            public TestableEchoConnection(IConnectionWrapper connWrapper)
                : base(connWrapper) { }

            public new Task OnReceived(IRequest req, string id, string data)
            {
                return base.OnReceived(req, id, data);
            }
            public new Task OnConnected(IRequest req, string id)
            {
                return base.OnConnected(req, id);
            }
        }

        [TestMethod]
        public void On_Connected_Sends_Private_And_Broadcast_Messages()
        {
            // Arrange
            var mockConnection = new Mock<IConnectionWrapper>();
            var myConnId = "1234";
            mockConnection
                .Setup(c => c.Send(It.IsAny<string>(), It.IsAny<object>()))
                .Returns(Task.FromResult(true))
                .Verifiable();

            mockConnection
                .Setup(c => c.Broadcast(It.IsAny<object>()))
                .Returns(Task.FromResult(true))
                .Verifiable();

            var echo = new TestableEchoConnection(mockConnection.Object);

            var mockRequest = new Mock<IRequest>();
            /*
            var identity = new GenericPrincipal(new GenericIdentity("jmaguilar"), new[] { "admin" });
            mockRequest.Setup(r => r.User).Returns(identity);
            */

            //Act
            echo.OnConnected(mockRequest.Object, myConnId).Wait();

            // Assert
            mockConnection.Verify();

        }

        [TestMethod]
        public void On_Received_Sends_Private_Message_To_Authenticated_User()
        {
            // Arrange
            var mockConnection = new Mock<IConnectionWrapper>();
            var myConnId = "1234";
            var expectedMessage = "jmaguilar> Hello";
            mockConnection
                .Setup(c => c.Send(It.IsAny<string>(), It.IsAny<object>()))
                .Returns(Task.FromResult(true));

            var echo = new TestableEchoConnection(mockConnection.Object);

            var mockRequest = new Mock<IRequest>();
            var identity = new GenericPrincipal(new GenericIdentity("jmaguilar"), new[] { "admin" });
            mockRequest.Setup(r => r.User).Returns(identity);

            //Act
            echo.OnReceived(mockRequest.Object, myConnId, "Hello").Wait();

            // Assert
            mockConnection.Verify(c => c.Send(myConnId, expectedMessage), Times.Once());
        }

        [TestMethod]
        public void On_Received_Sends_Private_Message_To_Anonymous_User()
        {
            // Arrange
            var mockConnection = new Mock<IConnectionWrapper>();
            var myConnId = "1234";
            var expectedMessage = "1234> Hello";
            mockConnection
                .Setup(c => c.Send(It.IsAny<string>(), It.IsAny<object>()))
                .Returns(Task.FromResult(true));

            var echo = new TestableEchoConnection(mockConnection.Object);

            var mockRequest = new Mock<IRequest>();
            var mockIdentity = new Mock<IIdentity>();
            mockIdentity.Setup(i=>i.IsAuthenticated).Returns(false);
            mockRequest.Setup(r => r.User).Returns(new GenericPrincipal(mockIdentity.Object, null));

            //Act
            echo.OnReceived(mockRequest.Object, myConnId, "Hello").Wait();

            // Assert
            mockConnection.Verify(c => c.Send(myConnId, expectedMessage), Times.Once());
        }
    }
}
