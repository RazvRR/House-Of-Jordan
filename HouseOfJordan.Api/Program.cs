using HouseOfJordan.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Adăugăm suport pentru controllere
builder.Services.AddControllers();

// Înregistrăm serviciul nostru pentru sneakers
builder.Services.AddScoped<ISneakerService, SneakerService>();

// Swagger (documentație API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Activăm Swagger în Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
