using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalLibrary
{
    public class NetworkMessage
    {
        static readonly TimeSpan TimeToLive = TimeSpan.FromSeconds(10);

        private readonly DateTime _creation;
        private Status _status;
        private readonly object _content;

        public NetworkMessage(Status status, object content)
        {
            _creation = DateTime.UtcNow;
            _status = status;
            _content = content;
        }

        public bool IsSuccess()
        {
            if (HasTimedOut())
                _status = Status.Failed;
            return _status == Status.Succeeded;
        }

        private bool HasTimedOut()
        {
            return (_creation.Add(TimeToLive)) < DateTime.UtcNow;
        }

        public T GetContentAs<T>() where T : class
        {
            var castedContent = _content as T;
            if (castedContent == null)
                throw new InvalidCastException("contet couldn't be casted into " + typeof(T));
            return _content as T;
        }
    }
}
