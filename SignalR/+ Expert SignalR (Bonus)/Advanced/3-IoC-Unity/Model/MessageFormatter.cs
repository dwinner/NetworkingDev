using System.Diagnostics;

namespace IocUnity.Model
{
    public class MessageFormatter : IMessageFormatter
    {
        private readonly IClock _clock;

        public MessageFormatter(IClock clock)
        {
            Debug.WriteLine("    Creating formatter");
            _clock = clock;
        }

        public string Format(string message)
        {
            return _clock.GetCurrentDateTime() + " > " + message;
        }

        public void Dispose()
        {
            Debug.WriteLine("    Disposing formatter");
        }
    }
}