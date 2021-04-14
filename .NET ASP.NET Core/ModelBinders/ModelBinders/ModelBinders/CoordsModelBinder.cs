using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelBinders.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ModelBinders.ModelBinders
{
    public class CoordsModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var valueProviderResult = bindingContext.ValueProvider.GetValue("coord");

            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            var coordValue = valueProviderResult.FirstValue;

            if (String.IsNullOrEmpty(coordValue))
            {
                return Task.CompletedTask;
            }

            var coordsArray = coordValue.Split(',').Select(c => int.Parse(c)).ToArray();
            bindingContext.Result = ModelBindingResult.Success(coordsArray);
            return Task.CompletedTask;
        }
    }
}
