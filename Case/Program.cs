using Case.Configuration;
using Case.Helper;
using Case.Repository;
using Case.Services;
using Case.Validators;
using Case.Validators.Demands;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// fluent validation ekliyoruz RegisterValidatorsFromAssemblyContaining diðer fluent validationlarý bulmasý için tanýmlýyoruz
// validationda filter sistemi ile data controllera gelmeden validation kontrolü yapýcaðýz

// oluþturduðumuz filterý ekliyoruz
builder.Services
    .AddControllersWithViews(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateDemandValidator>())
    // mevcut olan validation filterleri görmezden gel
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);
builder.Services.AddHttpClient();
// database conntection string'i tanýmlýyoruz
builder.Services.AddDatabaseModule(builder.Configuration);
// repository addscoped yapýlýyor
builder.Services.SetRepositoryConfiguration();
// services addscoped yapýlýyor
builder.Services.SetServicesConfiguration();
// helper AddScoped yapýlýyor
builder.Services.SetHelperConfiguration();
// auto mapper'ý ekliyoruz
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Proje farklý bir bilgisayarda ayaklandýðýnda otomatik db'yi oluþturur
await CreateDatabase.CreateDb(app);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
