using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Case.Validators
{
    /// <summary>
    /// Validation filter 
    /// validation filter tanımlamak için IAsyncActionFilter'den kalıtım alıyoruz
    /// </summary>
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                    .Where(x => x.Value.Errors.Any())
                    .SelectMany(x => x.Value.Errors.Select(err => err.ErrorMessage))
                    .ToList();

                context.Result = new BadRequestObjectResult(errors);
                return;
            }

            await next();
        }
    }
}
