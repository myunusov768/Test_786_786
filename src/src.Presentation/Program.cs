using src.BusinessLigic;
using src.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddDbContext<OsonDbContex>();
builder.Services.AddSingleton(builder.Configuration.GetSection("AppSettings").Get<AppSettings>());
builder.Services.AddSingleton<IBaseRepository, BaseRepository>();
builder.Services.AddSingleton<IInfrastructure, Infrastructure>();
builder.Services.AddSingleton<ICheckInfrastructure, CheckInfrastructure>();
builder.Services.AddHttpClient<IInfrastructure, Infrastructure>();
builder.Services.AddHttpClient<ICheckInfrastructure, CheckInfrastructure>();
builder.Services.AddHostedService<JobImon>();

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
