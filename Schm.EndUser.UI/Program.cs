using Schm.EndUser.UI.Infrastructure.Config;
using Schm.EndUser.UI.Infrastructure.Contracts;
using Schm.EndUser.UI.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<Config>(builder.Configuration.GetSection("Config"));
builder.Services.Configure<JwtInfo>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddScoped<IBrandTypeService, BrandTypeService>();
builder.Services.AddScoped<IItemCategoryService, ItemCategoryService>();
builder.Services.AddScoped<IItemSubCategoryService, ItemSubCategoryService>();
builder.Services.AddScoped<ISupplierItemService, SupplierItemService>();
builder.Services.AddScoped<IShopService, ShopService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddSession();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
