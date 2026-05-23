using Backend;
using Backend.Api.ExceptionMapper;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMongoDb(builder.Configuration)
    .AddJwt(builder.Configuration)
    .AddApplicationServices()
    .AddRepositories()
    .AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddExceptionHandler<GlobalExceptionMapper>();
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseExceptionHandler();
app.UseHttpsRedirection();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();

app.Run();
