using Castle.DynamicProxy;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    /// <summary>
    /// Interception araya girmek demekmiş
    /// </summary>
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        /// <summary>
        /// invocation: business method demekmiş yani get update delete işlemleri demek
        /// </summary>
        /// <param name="invocation"></param>
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
                var result = invocation.ReturnValue as Task;
                if (result != null)
                    result.Wait();

            }
            catch (System.Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}
