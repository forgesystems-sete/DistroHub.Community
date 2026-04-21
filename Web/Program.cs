using DistroHub.Application.Services;
using DistroHub.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages(o => o.RootDirectory = "/Web/Pages");
builder.Services.AddSingleton<JsonDistroRepository>();
builder.Services.AddScoped<DistroService>();
builder.Services.AddResponseCompression(o => o.EnableForHttps = true);

var app = builder.Build();

if (!app.Environment.IsDevelopment()) { app.UseExceptionHandler("/Error"); app.UseHsts(); }

app.UseHttpsRedirection();
app.UseResponseCompression();
app.UseStaticFiles();
app.Use(async (ctx, next) => {
    ctx.Response.Headers["X-Frame-Options"]        = "SAMEORIGIN";
    ctx.Response.Headers["X-Content-Type-Options"] = "nosniff";
    ctx.Response.Headers["Referrer-Policy"]        = "no-referrer";
    await next();
});
app.UseRouting();
app.MapRazorPages();
app.Run();
