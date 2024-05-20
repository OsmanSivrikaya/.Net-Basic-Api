using Case.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Case.Configuration
{
    public static class CreateDatabase
    {
        public async static Task CreateDb(IApplicationBuilder app)
        {
            //inject yapmak için scop oluşturuyoruz
            var scope = app.ApplicationServices.CreateScope();
            //context nesnesini scope ile çekiyoruz
            var context = scope.ServiceProvider.GetService<Context>();

            //migration'ları sistem her çalıştığımda çalıştırır (NOT: sadece çalışmamışları)
            try
            {
                await context?.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
