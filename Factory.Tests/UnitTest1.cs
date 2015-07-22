using ExternalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oinant.Blog.Factory.ForTesting;

namespace Factory.Tests
{
    [TestClass]
    public class ClientTests
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }

    public class TestFactory : INetworkMessageFactory
    {
        public NetworkMessage Create(Status status, object content)
        {
            var message = new NetworkMessageDouble(status, content);
            return message;
        }
    }

    class NetworkMessageDouble : NetworkMessage
    {
        private readonly Status _status;
        private readonly object _content;

        public NetworkMessageDouble(Status status, object content) : base(status, content)
        {
            _status = status;
            _content = content;
        }

        public new bool IsSuccess()
        {
            return _status == Status.Succeeded;
        }

        public T GetContentAs<T>() where T : class
        {
            return  _content as T;
        }
    }
}
