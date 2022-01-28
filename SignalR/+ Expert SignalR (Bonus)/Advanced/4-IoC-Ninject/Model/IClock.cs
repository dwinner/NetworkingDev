using System;

namespace IocNinject.Model
{
    public interface IClock: IDisposable
    {
        string GetCurrentDateTime();
    }
}