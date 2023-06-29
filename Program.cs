var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<E_CommerceDbContext>(opts => {
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:E_CommerceConnection"]);
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

builder.Services.AddTransient<IProduct, ProductRepository>();
builder.Services.AddTransient<IOrder, OrderRepository>();
builder.Services.AddScoped<Cart>(x => SessionCart.GetCart(x));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();
app.UseSession();

SeedData.EnsurePopulated(app, app.Environment);
app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.Run();
