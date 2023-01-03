using SubjectService.Services;
using SubjectService.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SubjectServiceDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SubjectService"));
});

builder.Services.AddTransient<ISubjectsService, SubjectsService>();
builder.Services.AddTransient<IMessagingService, MessagingService>();
builder.Services.AddTransient<ISubjectDAL, SubjectDAL>();
builder.Services.AddTransient<IStudentDAL, StudentDAL>();
builder.Services.AddTransient<SubjectServiceDBContext>();

var message = new MessagingService();
message.checkMessage();

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
