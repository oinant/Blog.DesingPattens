using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExternalLibrary;

namespace Oinant.Blog.Factory.ForTesting
{
    public abstract class SuperSimpleNetworkClientBase
    {
        public abstract string SendRequest();

        protected string ExtractSummaryFrom(NetworkMessage message)
        {
            return message.IsSuccess().ToString() + " " + message.GetContentAs<string>();
        }
    }


    namespace WithoutFactory
    {
        public class NetworkClientWithoutMessageFactory : SuperSimpleNetworkClientBase
        {
            public override string SendRequest()
            {
                var message = new NetworkService().SendMessage();
                var networkMessage = new NetworkMessage((Status)message.Item1, message.Item2);

                return ExtractSummaryFrom(networkMessage);
            }
        }

    }


    namespace WithFactory
    {

        public class NetworkClientWithMessageFactory : SuperSimpleNetworkClientBase
        {
            public override string SendRequest()
            {
                var message = new NetworkService().SendMessage();
                var networkMessage = new NetworkMessage((Status)message.Item1, message.Item2);

                return ExtractSummaryFrom(networkMessage);
            }
        }

        public interface INetworkMessageFactory
        {
            NetworkMessage Create(Status status, object content);
        }


        
    }

}
