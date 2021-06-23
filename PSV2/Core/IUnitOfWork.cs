using System;
namespace PSV2.Core
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
    }
}
