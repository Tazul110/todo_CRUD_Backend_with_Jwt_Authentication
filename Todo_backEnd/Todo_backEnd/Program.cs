using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Todo_backEnd.Repository;
using Todo_backEnd.Repository.LogInRepositoryImpl;
using Todo_backEnd.Repository.LogInRepositoryInterface;
using Todo_backEnd.Repository.RepositoryImpl;
using Todo_backEnd.Service.LogInServiseImpl;
using Todo_backEnd.Service.LogInServiseInterface;
using Todo_backEnd.Service.serviceImpl;
using Todo_backEnd.Service.serviceInterface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            /*ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))*/
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };

    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAddUserRegistration, AddUserRegistration>();
builder.Services.AddScoped<IAddUserRegistrationServ, AddUserRegistrationServ>();

builder.Services.AddScoped<IGetUserByEmail, GetUserByEmail>();
builder.Services.AddScoped<IGetUserByEmailServ, GetUserByEmailServ>();

builder.Services.AddScoped<ICrudGetByIdService, CrudGetByIdService>();

builder.Services.AddScoped<ICrudGetById, CrudGetById>();
builder.Services.AddScoped<ICrudGetByIdService, CrudGetByIdService>();

builder.Services.AddScoped<ICrudUpdate, CrudUpdate>();
builder.Services.AddScoped<ICrudUpdateService, CrudUpdateService>();

builder.Services.AddScoped<ICrudDelete, CrudDelete>();
builder.Services.AddScoped<ICrudDeleteService, CrudDeleteService>();

builder.Services.AddScoped<ICrudAdd, CrudAdd>();
builder.Services.AddScoped<ICrudAddService, CrudAddService>();

builder.Services.AddScoped<ICrudGet, CrudGet>();
builder.Services.AddScoped<ICrudGetService, CrudGetService>();





var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseAuthorization();

app.MapControllers();

app.Run();
