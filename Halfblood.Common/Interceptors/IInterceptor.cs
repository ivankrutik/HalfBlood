namespace Halfblood.Common.Interceptors
{
    public interface IInterceptor
    {
        void Intercept(object @object);
    }

    public abstract class InterceptorBase<TInterceptableObject> : IInterceptor
        where TInterceptableObject : class 
    {
        void IInterceptor.Intercept(object @object)
        {
            var interceptableObject = @object as TInterceptableObject;

            if (interceptableObject != null)
            {
                Intercept(interceptableObject);
            }
        }

        public abstract void Intercept(TInterceptableObject interceptableObject);
    }
}