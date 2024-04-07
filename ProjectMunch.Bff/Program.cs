using Asp.Versioning;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using ProjectMunch.Bff;
using StackExchange.Redis;
using Yarp.ReverseProxy.Forwarder;
using Yarp.ReverseProxy.Transforms;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder
    .Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(o =>
    {
        o.Cookie.SecurePolicy = CookieSecurePolicy.None;
        o.Cookie.SameSite = SameSiteMode.None;
        o.Cookie.HttpOnly = true;
    });

builder.Services.AddCors(o =>
{
    o.AddPolicy(
        name: "cors-policy",
        p =>
        {
            p.WithOrigins("https://localhost:5173")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        }
    );
});

builder.Services.AddHttpClient<ApiClient>(o =>
{
    o.BaseAddress = new("https://localhost:7136/api/v1/");
});

builder.Services.AddSingleton<IConnectionMultiplexer>(
    ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("Redis")!)
);
builder.Services.AddScoped<ICacheService, CacheService>();

builder.Services.AddApiVersioning(opt =>
{
    opt.ReportApiVersions = true;
    opt.DefaultApiVersion = new ApiVersion(1, 0);
    opt.ApiVersionReader = new UrlSegmentApiVersionReader();
    opt.AssumeDefaultVersionWhenUnspecified = true;
});

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});

builder
    .Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"))
    .AddTransforms(o =>
    {
        if (string.IsNullOrEmpty(o.Route.AuthorizationPolicy))
        {
            o.AddRequestTransform(c =>
            {
                var accessToken = c
                    .HttpContext.User.Claims.FirstOrDefault(c => c.Type == "AccessToken")
                    ?.Value;

                if (!string.IsNullOrEmpty(accessToken))
                {
                    c.ProxyRequest.Headers.Authorization = new("Bearer", accessToken);
                }

                return ValueTask.CompletedTask;
            });
        }
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("cors-policy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapReverseProxy();

app.Run();
