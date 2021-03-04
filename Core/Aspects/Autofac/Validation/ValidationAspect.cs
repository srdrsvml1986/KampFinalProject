using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using FluentValidation;
using System;
using System.Linq;

namespace Core.Aspects.Autofac.Validation
{
    /// <summary>
    /// ValidationAspect
    /// </summary>
    public class ValidationAspect : MethodInterception
    {
        private readonly Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //defensive coding
            //IsAssignableFrom: atanabiliyor mu
            //Gelen validatorType ın IValidator Type olup olmadığı kontrol ediliyor
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new ArgumentException(AspectMessages.WrongValidationType);
            }
            _validatorType = validatorType;
        }
        /// <summary>
        /// invocation: örneğin "Add" methodu
        /// </summary>
        /// <param name="invocation"></param>
        protected override void OnBefore(IInvocation invocation)
        {
            //Activator: çalışma anında Instance oluşturmak için
            //biz gelen Type ın(_validatorType) IValidator olduğunu bilgidiğimizden
            //doğrudan convert ediyoruz
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //_validatorType: örneğin "ProductValidator" bunun base Type ı "AbstractValidator"
            //ve biz kesin biliyoruz ki base Type ın bir adet argumani var "AbstractValidator<Product>"
            //arguman: örneğin "Product"
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //entityType: örneğin "Product"
            //"public IResult Add(Product product)" gibi methodun argumanlarını gez
            //Type ı entityType Type olan Arguments leri getir
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            //burada "Add" methodunun argumanları bir tane "product"
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
