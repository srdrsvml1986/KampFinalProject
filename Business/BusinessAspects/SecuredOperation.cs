using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Business.BusinessAspects
{
    /// <summary>
    ///This Aspect control the user's roles in HttpContext by inject the IHttpContextAccessor.
    ///It is checked by writing as [SecuredOperation] on the handler.
    ///If a valid authorization cannot be found in aspec, it throws an exception.
    /// </summary>

    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            try
            {
                var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
                foreach (var role in _roles)
                {
                    if (roleClaims.Contains(role))
                    {
                        return;
                    }
                }
            }
            catch (Exception)
            {

            }

            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
