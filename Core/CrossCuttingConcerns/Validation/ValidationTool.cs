using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        /// <summary>
        /// VAlidator:ilgili methodun parametrelerini validete etmek istediğimiz
        /// FluentValidatin classı => ProductValidator class Doğrulama kurallarının olduğu class
        /// entity ise validate edilecek tablo class doğrulacak class
        /// </summary>
        /// <param name="validator"></param>
        /// <param name="entity"></param>
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);

            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
