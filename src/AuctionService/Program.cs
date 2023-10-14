using AuctionService.Consumers;
using AuctionService.Data;
using AuctionService.interfaces;
using AuctionService.Repostiories;
using AuctionService.Services;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AuctionDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// MASS TRANSIT using RabbitMQ
builder.Services.AddMassTransit(x => 
{
    x.AddEntityFrameworkOutbox<AuctionDbContext>(opt => 
    {
        opt.QueryDelay = TimeSpan.FromSeconds(10);
        opt.UsePostgres();
        opt.UseBusOutbox();
    });

    // CONSUMERS - No need to add individual consumers if they are in the same namespace
    x.AddConsumersFromNamespaceContaining<AuctionCreatedFaultsConsumer>();

    x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("auction", false));

    x.UsingRabbitMq((context, cfg) => 
    {
        cfg.Host(builder.Configuration["RabbitMq:Host"], "/", host =>
        {
            host.Username(builder.Configuration.GetValue("RabbitMq:Username", "guest"));
            host.Password(builder.Configuration.GetValue("RabbitMq:Password", "guest"));
        });
        
        cfg.ConfigureEndpoints(context);
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.Authority = builder.Configuration["IdentityServiceUrl"];
        opt.RequireHttpsMetadata = false;
        opt.TokenValidationParameters.ValidateAudience = false;
        opt.TokenValidationParameters.NameClaimType = "username";
    });

builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.

ConfigureServices();

void ConfigureServices()
{
    IdentityModelEventSource.ShowPII = true;
}

app.UseAuthentication(); // must be b4 UseAuthorization or will get a 404
app.UseAuthorization();

app.MapControllers();
app.MapGrpcService<GrpcAuctionService>();

try
{
    DbInitializer.InitDb(app);
}
catch (Exception e)
{
    
    Console.WriteLine(e);
}

app.Run();
