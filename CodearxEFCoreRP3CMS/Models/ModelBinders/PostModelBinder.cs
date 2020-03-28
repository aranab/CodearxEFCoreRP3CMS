using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodearxEFCoreRP3CMS.Models.ModelBinders
{
    public class PostModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            if (bindingContext.ModelName != "Tags")
            {
                return Task.CompletedTask;
            };

            var value = bindingContext.ValueProvider.GetValue("Tags").FirstValue;

            // Check if the argument value is null or WhiteSpace
            if (string.IsNullOrWhiteSpace(value))
            {
                bindingContext.Result = ModelBindingResult.Success(new List<string>());
                return Task.CompletedTask;
            }

            var tags = value.Split(new[] { ',' }).Select(t => t.Trim()).ToList();
            bindingContext.Result = ModelBindingResult.Success(tags);

            return Task.CompletedTask;
        }
    }
}
