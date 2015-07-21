using System;

namespace ExternalLibrary
{
    public class NetworkService
    {
        public Tuple<int, object> SendMessage()
        {
            // for ske of simplicity, some static data...
            return new Tuple<int, object>(1, new object());
        }
    }
}