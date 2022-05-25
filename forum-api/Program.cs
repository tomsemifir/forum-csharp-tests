using forum_api;
using forum_api.Repositories.Impl;
using forum_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Context
builder.Services.AddDbContext<forumContext>();
//Repositories
builder.Services.AddTransient<MessageRepository>();
builder.Services.AddTransient<TopicRepository>();
//Services
builder.Services.AddSingleton<WordFilterService>();
builder.Services.AddTransient<MessageService>();
builder.Services.AddTransient<TopicService>();
//Cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
