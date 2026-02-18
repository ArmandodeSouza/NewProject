using Microsoft.Extensions.DependencyInjection;
using NewProject.Application.Interfaces;
using NewProject.Application.Services;
using NewProject.Domain.Interfaces;
using NewProject.Infrastructure.Abstraction;
using NewProject.Infrastructure.Data;
using NewProject.Infrastructure.Repositorys;

namespace NewProject.UI {
    internal static class Program {


        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main() {
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            ConfigureServices(services);

            ServiceProvider = services.BuildServiceProvider();

            var mainForm = ServiceProvider.GetRequiredService<Form1>();
            System.Windows.Forms.Application.Run(mainForm);
        }

        private static void ConfigureServices(IServiceCollection services) {

            string connectionString = "Host=localhost;Port=5432;Database=ProjetoVendas;Username=postgres;Password=123";

            services.AddSingleton<IDbConnectionFactory>(_ => new DbConnectionFactory(connectionString));
            // Forms
            services.AddTransient<Form1>();

            // Application
            services.AddTransient<IClienteService, ClienteService>();

            // Infrastructure
            services.AddTransient<IClienteRepository, ClienteRepository>();
        }
    }
}