using BE.Infra.Data;

var builder = WebApplication.CreateBuilder(args);

//add services toDI container
{
    var services = builder.Services;
    var env = builder.Environment;

    //use sql server db in production and sqlite db in development
    if (env.IsProduction())
    {
        services.AddDbContext<BEContext>();
    }
    else
    {
        services.AddDbContext<BEContext, SqliteDataContext>();
    }

    
    // Add services to the container.
    services.AddCors();
    services.AddControllers();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
}

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
