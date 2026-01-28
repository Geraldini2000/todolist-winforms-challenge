using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows.Forms;
using TodoApp.Infrastructure.Data;

namespace TodoApp;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();


        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddDbContext<AppDbContext>(options =>
                    options.UseNpgsql(
                        context.Configuration.GetConnectionString("DefaultConnection")));
            })
            .Build();

        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;

        System.Windows.Forms.Application.Run(new Form1());
    }
}
