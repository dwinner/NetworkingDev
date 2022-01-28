using System;

namespace IocUnity.Model
{
    public interface IMessageFormatter: IDisposable
    {
        string Format(string message);
    }
}