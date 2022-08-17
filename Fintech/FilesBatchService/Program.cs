
using FilesBatchService;
using FilesBatchService.Models;
using Microsoft.EntityFrameworkCore;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddDbContext<FintechContext>(options =>
            options.UseSqlServer("Server=DEV-DIANAD\\MSSQLSERVER2019;Database=Fintech;User ID=sa;Password=Bizagi2018;Trusted_Connection=True;"));
        

        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
