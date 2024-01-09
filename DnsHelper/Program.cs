using AspNetCoreRateLimit;
using DnsClient;
using DnsHelper.Helper;
using DnsHelper.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDnsHelperService, DnsHelperService>();


//DnsClient .net
LookupClient client = new()
{
    UseCache = true
};
builder.Services.AddSingleton<ILookupClient>(client);
//DnsClient .net


//AspNetCoreRateLimit

//Her bir IP için 1 saniye içinde en fazla 5 istek yapılabileceğini belirtiyoruz.


builder.Services.AddMemoryCache();
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));

builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
builder.Services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

//AspNetCoreRateLimit

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseIpRateLimiting();

app.UseMiddleware<HttpLoggingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
