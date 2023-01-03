using Microsoft.EntityFrameworkCore;
using StudentService.DataAccessLayer;
using StudentService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StudentServiceDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudentService"));
});

builder.Services.AddTransient<IStudentsService, StudentsService>();
builder.Services.AddTransient<IMessagingService, MessagingService>();
builder.Services.AddTransient<IStudentDAL, StudentDAL>();
builder.Services.AddTransient<StudentServiceDBContext>();

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
