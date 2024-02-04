
using grpc.test.pro.Interceptors;
using grpc.test.pro.Services;
using grpc_test_pro.Services;
using grpctestpro.Database;
using Calzolari.Grpc.AspNetCore.Validation;
using FluentValidation;
using grpc.test.pro.Validator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc(
    Option =>
    {
        Option.EnableMessageValidation();
        Option.Interceptors.Add<HandleErrorInterception>();
    });

builder.Services.AddValidator<ProductValidator>();
builder.Services.AddValidator<IdValidator>();
builder.Services.AddValidator<PageValidator>();
builder.Services.AddValidator<UpdateProductValidator>();
builder.Services.AddGrpcValidation();


builder.Services.AddSingleton<DbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<ProductsService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
