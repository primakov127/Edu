using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelBinders.ModelBinders
{
    public class PersonIdModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var valueProviderResult = bindingContext.ValueProvider.GetValue("personId");

            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            var userIdValue = valueProviderResult.FirstValue;

            if (String.IsNullOrEmpty(userIdValue))
            {
                return Task.CompletedTask;
            }

            var bytes = Convert.FromBase64String(userIdValue);
            var decodedUserId = Encoding.UTF8.GetString(bytes);
            var result = new Guid(decodedUserId);
            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;
        }
    }
}
