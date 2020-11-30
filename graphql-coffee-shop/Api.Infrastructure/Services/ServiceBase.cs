using System;
using AutoMapper;

namespace Teqniqly.Samples.Graphql.CoffeeShop.Services
{
    public abstract class ServiceBase : IDisposable
    {
        protected IDataStoreService DataStoreService { get; }
        protected IMapper Mapper { get; }

        private bool _disposed;

        protected ServiceBase(IDataStoreService dataStoreService, IMapper mapper)
        {
            DataStoreService = dataStoreService;
            Mapper = mapper;
        }

        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                ((IDisposable)DataStoreService).Dispose();
            }

            _disposed = true;
        }
    }
}
