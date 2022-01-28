using System;

namespace IocUnity.Model
{
    public interface IClock: IDisposable
    {
        string GetCurrentDateTime();
    }
}