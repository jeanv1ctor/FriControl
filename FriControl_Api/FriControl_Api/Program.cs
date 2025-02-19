using System.Text.Json.Serialization;
using FriControl_Api.Data;
using FriControl_Api.Service;
using FriControl_Api.Service.CategoriaItemService;
using FriControl_Api.Service.ForncedorService;
using FriControl_Api.Service.FuncionarioService;
using FriControl_Api.Service.SetorFuncionarioService;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IItemInterface, ItemService>();
builder.Services.AddScoped<IFuncionarioInterface, FuncionarioService>();
builder.Services.AddScoped<ICategoriaItemInterface, CategoriaItemService>();
builder.Services.AddScoped<ISetorFuncionarioInterface, SetorFuncionarioService>();
builder.Services.AddScoped<IFornecedorInterface, FornecedorService>();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
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

app.MapControllers();

app.Run();