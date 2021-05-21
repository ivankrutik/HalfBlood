namespace Halfblood.Common.Interceptors
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Reactive.Linq;

    [Export(typeof(IInterceptorManager))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class InterceptorManager : IInterceptorManager
    {
        private readonly IInterceptorsProvider _interceptorsProvider;

        [ImportingConstructor]
        public InterceptorManager(IInterceptorsProvider interceptorsProvider)
        {
            _interceptorsProvider = interceptorsProvider;
        }

        public void Intercept(object @object)
        {
            _interceptorsProvider.GetInterceptors().DoForEach(x => x.Intercept(@object));
        }
    }

    [Export(typeof(IInterceptorsProvider))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class InterceptorsProvider : IInterceptorsProvider, IPartImportsSatisfiedNotification
    {
        [ImportMany]
        private Lazy<IInterceptor>[] _interceptorsLazy;
        private readonly IList<IInterceptor> _interceptors = new List<IInterceptor>();

        public void Unregister(IInterceptor interceptor)
        {
            _interceptors.Remove(interceptor);
        }

        public IEnumerable<IInterceptor> GetInterceptors()
        {
            return _interceptors;
        }

        public void Register(IInterceptor interceptor)
        {
            _interceptors.Add(interceptor);
        }

        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            foreach (Lazy<IInterceptor> lazy in _interceptorsLazy)
            {
                _interceptors.Add(lazy.Value);
            }
        }
    }

    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class InterceptorAttribute : ExportAttribute
    {
        public InterceptorAttribute()
            : base(typeof(IInterceptor))
        {
        }
    }
}
