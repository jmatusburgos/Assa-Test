using Test_Car.Ioc.ServiceCollectionExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add Context
DbContext.AddDbContext(builder.Services, connectionString: builder.Configuration.GetConnectionString("DefaultConnection"));

//Register dependencies for services, repositories and unitOfWork
builder.Services.ConfigureDependencyInjenction();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.ApplyMigrations();
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
