using SchoolManagementSystem.Infrastructure;
using SchoolManagementSystem.Application;
using Azure.Storage.Blobs;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton(x=> new BlobServiceClient(builder.Configuration.GetValue<string>("BlobStorage:ConnectionString")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        corsBuilder => corsBuilder.WithOrigins("http://localhost:5173")
                                  .AllowAnyHeader()
                                  .AllowAnyMethod()
                                  );
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");
app.UseAuthorization();
app.MapControllers();
app.Run();
