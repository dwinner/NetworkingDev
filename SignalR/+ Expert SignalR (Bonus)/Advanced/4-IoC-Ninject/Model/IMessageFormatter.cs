using System;

namespace IocNinject.Model
{
    public interface IMessageFormatter: IDisposable
    {
        string Format(string message);
    }
}