using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TodoApp.Application.Tasks;
using TodoApp.Domain.Repositories;
using TodoApp.Infrastructure.Data;
using TodoApp.Infrastructure.Repositories;

namespace TodoApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            using IHost host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddDbContext<AppDbContext>(options =>
                        options.UseNpgsql(
                            context.Configuration.GetConnectionString("DefaultConnection")));

                    // Repositories
                    services.AddScoped<ITaskRepository, TaskRepository>();

                    // Use Cases (Application)
                    services.AddScoped<CreateTaskUseCase>();
                    services.AddScoped<CompleteTaskUseCase>();

                    // Forms
                    services.AddScoped<Form1>();
                })
                .Build();

            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            var mainForm = services.GetRequiredService<Form1>();
            System.Windows.Forms.Application.Run(mainForm);
        }
    }
}
