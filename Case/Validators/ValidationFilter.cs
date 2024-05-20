using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

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
            // modal is valid değilse giriyor
            if (!context.ModelState.IsValid)
            {
                var erros = context.ModelState
                    .Where(x => x.Value.Errors.Any())
                    //key'i ve ona karşılık gelen validation mesajlarını çekiyoruz
                    .ToDictionary(e => e.Key, e => e.Value.Errors.Select(e => e.ErrorMessage))
                    .ToArray();

                context.Result = new BadRequestObjectResult(erros);
                return;
            }
            //bir sonraki deleget'i çalıştır
            await next();
        }
    }
}
