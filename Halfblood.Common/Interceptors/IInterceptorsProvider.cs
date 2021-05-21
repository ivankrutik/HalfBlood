namespace Halfblood.Common.Interceptors
{
    using System.Collections.Generic;

    public interface IInterceptorsProvider
    {
        void Register(IInterceptor interceptor);
        void Unregister(IInterceptor interceptor);
        IEnumerable<IInterceptor> GetInterceptors();
    }
}