using repository.pgsql;
using repository;
using setting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.Configure<ConnectionSetting>(builder.Configuration.GetSection("ConnectionSetting"));
builder.Services.AddScoped<IPatientRepository, PatientRepositoryImpl>();
builder.Services.AddScoped<IProviderRepository, ProviderRepositoryImpl>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var corsOptions = "corsOptions";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsOptions,
                      policy  =>
                      {
                          policy.WithOrigins("https://localhost:5173" /*,"https://localhost:5155"*/);
                          policy.WithMethods(new string[]{"GET","POST","PUT","DELETE"});
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(corsOptions);

app.MapControllers();

app.Run();
