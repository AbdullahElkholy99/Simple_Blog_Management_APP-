using SimpleBlog.Data;
using SimpleBlog.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureSqlServer(builder.Configuration);
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureCors();
builder.Services.ConfigureBlogService();
//builder.Services.AddScoped<IBlogService, BlogService>();

///Using Auto Mapper 
builder.Services.AddAutoMapper(typeof(Program));




var app = builder.Build();

var logger = app.Services.GetRequiredService<ILogger<AppDbContext>>();
app.ConfigureExceptionHandler(logger);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.All
});

app.UseCors("CorsPolicy");


app.UseAuthorization();

app.MapControllers();

app.Run();
