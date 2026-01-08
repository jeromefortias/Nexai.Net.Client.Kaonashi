using Localhost.AI.KaonashiWeb;
using Localhost.AI.KaonashiWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

// Load configuration
var config = AppConfig.Load();

// Register services
builder.Services.AddSingleton<AppConfig>(config);
builder.Services.AddScoped<OllamaService>(sp => 
    new OllamaService(config.OllamaHost, config.OllamaPort, config.CompletionHost, config.CompletionPort));
builder.Services.AddScoped<NewsService>(sp => 
    new NewsService(config.CompletionHost, config.CompletionPort));
builder.Services.AddScoped<LogService>(sp => 
    new LogService(config.CompletionHost, config.CompletionPort));

// Add session support for chat history
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add HttpContextAccessor for session access in controllers
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

// Log application startup
try
{
    var logService = app.Services.GetRequiredService<LogService>();
    logService.Log("INFO", "Kaonashi Web Client started");
}
catch
{
    // Ignore logging errors on startup
}

app.Run();
