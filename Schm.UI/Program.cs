using Schm.UI.Infrastructure.Config;
using Schm.UI.Infrastructure.Contracts;
using Schm.UI.Infrastructure.Middleware;
using Schm.UI.Infrastructure.Services;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//TODO : we should move below registeration to framework layer 
builder.Services.AddControllersWithViews();
builder.Services.Configure<Config>(builder.Configuration.GetSection("Config"));
builder.Services.Configure<JwtInfo>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddScoped<IBrandTypeService, BrandTypeService>();
builder.Services.AddScoped<IItemCategoryService, ItemCategoryService>(); 
builder.Services.AddScoped<IItemSubCatagoryService, ItemSubCatagoryService>();
builder.Services.AddScoped<IModelTypeService, ModelTypeService>();
builder.Services.AddScoped<IOptionTypeService, OptionTypeService>();
builder.Services.AddScoped<IItemImageService, ItemImageService>();
builder.Services.AddScoped<IItemService, ItemService>(); 
builder.Services.AddScoped<IItemUnitTypeService, ItemUnitTypeService>();
builder.Services.AddScoped<IItemOptionService, ItemOptionService>();
builder.Services.AddScoped<IOptionGroupTypeService, OptionGroupTypeService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<ISupplierItemService, SupplierItemService>();
builder.Services.AddScoped<ISupplierUserService, SupplierUserService>();
builder.Services.AddScoped<ILogesticTypeService, LogesticTypeService>();
builder.Services.AddScoped<IPaymentTypeService, PaymentTypeService>();
builder.Services.AddScoped<IOrderStatusService, OrderStatusService>();
builder.Services.AddScoped<IDocumentService, DocumentService>();
builder.Services.AddScoped<ISubDocumentService, SubDocumentService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddSession();

var app = builder.Build();

var loggerFactory = app.Services.GetService<ILoggerFactory>();
loggerFactory.AddFile(builder.Configuration["Logging:LogFilePath"].ToString());

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error/Error404");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseMiddleware<CheckSession>();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
