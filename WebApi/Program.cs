using Library.Command;
using Library.Query;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddCommandQueryHandlers(typeof(Program), typeof(ICommandHandler<>));
builder.Services.AddCommandQueryHandlers(typeof(Program), typeof(IQueryHandler<,>));
builder.Services.AddScoped<ICommandBus, CommandBus>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
