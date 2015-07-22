using ExternalLibrary;

namespace Oinant.Blog.Factory.ForTesting
{

    public class NetworkClientWithoutMessageFactory
    {
        public string SendRequest()
        {
            var message = new NetworkService().SendMessage();
            var networkMessage = new NetworkMessage((Status)message.Item1, message.Item2);

            return networkMessage.IsSuccess().ToString() + " " + networkMessage.GetContentAs<string>();
        }
    }

    public class NetworkClientWithMessageFactory
    {
        private readonly INetworkMessageFactory _networkMessageFactory;

        public NetworkClientWithMessageFactory(INetworkMessageFactory networkMessageFactory)
        {
            _networkMessageFactory = networkMessageFactory;
        }

        public string SendRequest()
        {
            var message = new NetworkService().SendMessage();
            var networkMessage = _networkMessageFactory.Create((Status)message.Item1, message.Item2);

            return networkMessage.IsSuccess().ToString() + " " + networkMessage.GetContentAs<string>();
        }
    }

    public interface INetworkMessageFactory
    {
        NetworkMessage Create(Status status, object content);
    }

    public class ConcreteNetworkMessageFactory : INetworkMessageFactory
    {
        public NetworkMessage Create(Status status, object content)
        {
            return new NetworkMessage(status, content);
        }
    }
}