using MultiTenantApi.AutoMapper;
using MultiTenantApi.Infrastructure;
using MultiTenantApi.Repositories;
using MultiTenantApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructureServices(builder.Configuration.GetConnectionString("MultiTenantDb"));
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
