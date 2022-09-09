using AutoMapper;
using Fintech.Application.Services;
using Fintech.Application.UseCases.CreateCredit;
using Fintech.Application.UseCases.CreateCreditEvaluation;
using Fintech.Application.UseCases.GetCredit;
using Fintech.Application.UseCases.GetCreditsPendding;
using Fintech.Application.UseCases.GetIdentityType;
using Fintech.Application.UseCases.Login;
using Fintech.Application.UseCases.UploadImagenCredit;
using Fintech.DA;
using Fintech.Domain;
using Fintech.DTOs;
using Fintech.Infrastructure.DataAccess;
using Fintech.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

//Enable cors
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

//Enable cors
builder.Services.AddCors(options =>
{

    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://172.24.27.177:3000")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

builder.Services.AddDbContext<FintechContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FintechContext") ?? throw new InvalidOperationException("Connection string 'FintechContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Mapper
var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperProfile());
});

var mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);
//Fin Mapper

//Injectar servies

/*builder.Services.AddTransient<ICreditRequestsDA, CreditRequestsDA>();
builder.Services.AddTransient<IIdentityTypeDA, IdentityTypeDA>();
builder.Services.AddTransient<ICustomerDA, CustomerDA>();*/
builder.Services.AddTransient<IFileService, FileService>();
builder.Services.AddTransient<IEmailService, EmailService>();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ICreditRepository, CreditRepository>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IIdentityTypeRepository, IdentityTypeRepository>();


builder.Services.AddTransient<ILoginUseCase, LoginUseCase>();
builder.Services.AddTransient<IUploadImagenCreditUseCase, UploadImagenCreditUseCase>();
builder.Services.AddTransient<IGetCreditsPenddingUseCase, GetCreditsPenddingUseCase>();
builder.Services.AddTransient<IGetCreditUserCase, GetCreditUserCase>();
builder.Services.AddTransient<ICreateCreditEvaluationUserCase, CreateCreditEvaluationUserCase>();
builder.Services.AddTransient<ICreateCreditUseCase, CreateCreditUseCase>();
builder.Services.AddTransient<IGetIdentityTypeUserCase, GetIdentityTypeUserCase>();



//FinInjectar servies




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

//Enable cors
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();


app.Run();
