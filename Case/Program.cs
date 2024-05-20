using Case.Configuration;
using Case.Helper;
using Case.Repository;
using Case.Services;
using Case.Validators;
using Case.Validators.Demands;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// fluent validation ekliyoruz RegisterValidatorsFromAssemblyContaining di�er fluent validationlar� bulmas� i�in tan�ml�yoruz
// validationda filter sistemi ile data controllera gelmeden validation kontrol� yap�ca��z

// olu�turdu�umuz filter� ekliyoruz
builder.Services
    .AddControllersWithViews(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateDemandValidator>())
    // mevcut olan validation filterleri g�rmezden gel
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);
builder.Services.AddHttpClient();
// database conntection string'i tan�ml�yoruz
builder.Services.AddDatabaseModule(builder.Configuration);
// repository addscoped yap�l�yor
builder.Services.SetRepositoryConfiguration();
// services addscoped yap�l�yor
builder.Services.SetServicesConfiguration();
// helper AddScoped yap�l�yor
builder.Services.SetHelperConfiguration();
// auto mapper'� ekliyoruz
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Proje farkl� bir bilgisayarda ayakland���nda otomatik db'yi olu�turur
await CreateDatabase.CreateDb(app);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
