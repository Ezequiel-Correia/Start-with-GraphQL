using Data.DataContext;
using Data.Repositories;
using Domain.Interfaces.Data;
using Domain.Interfaces.Services;
using Domain.Services;
using Microsoft.EntityFrameworkCore;
using Project_GraphQL.Mutations;
using Project_GraphQL.Queries;
using System;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("Project_GraphQL")));

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRespository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddGraphQLServer()
    .AddQueryType(d => d.Name(OperationTypeNames.Query))
    .AddTypeExtension<Query>()
    .AddMutationType<Mutation>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();
app.MapGraphQL();
app.Run();
