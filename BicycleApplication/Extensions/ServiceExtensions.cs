using System;
using BicycleApplication.Entities.Models;
using Contracts;
using Entities.Models;
using Repository;
using Service.Contracts;
using Services;

namespace BicycleApplication.Extensions
{
	public static class ServiceExtensions
	{
        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager<Bicycle>, RepositoryManager<Bicycle>>();
            services.AddScoped<IRepositoryManager<Mountain>, RepositoryManager<Mountain>>();
            services.AddScoped<IRepositoryManager<Highway>, RepositoryManager<Highway>>();
            services.AddScoped<IRepositoryManager<Gravel>, RepositoryManager<Gravel>>();
            services.AddScoped<IRepositoryManager<Electro>, RepositoryManager<Electro>>();

            services.AddScoped<IFilterRepository<Bicycle>, FilterRepository<Bicycle>>();
            services.AddScoped<IFilterRepository<Mountain>, FilterRepository<Mountain>>();
            services.AddScoped<IFilterRepository<Highway>, FilterRepository<Highway>>();
            services.AddScoped<IFilterRepository<Gravel>, FilterRepository<Gravel>>();
            services.AddScoped<IFilterRepository<Electro>, FilterRepository<Electro>>();
        }

        public static void ConfigureServiceManager(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager<Bicycle>, ServiceManager<Bicycle>>();
            services.AddScoped<IServiceManager<Mountain>, ServiceManager<Mountain>>();
            services.AddScoped<IServiceManager<Highway>, ServiceManager<Highway>>();
            services.AddScoped<IServiceManager<Gravel>, ServiceManager<Gravel>>();
            services.AddScoped<IServiceManager<Electro>, ServiceManager<Electro>>();
        }

        public static void ConfigureRepositoryContext(this IServiceCollection services)
        {
            services.AddScoped<RepositoryContext<Bicycle>>();
            services.AddScoped<RepositoryContext<Mountain>>();
            services.AddScoped<RepositoryContext<Highway>>();
            services.AddScoped<RepositoryContext<Gravel>>();
            services.AddScoped<RepositoryContext<Electro>>();

            services.AddScoped<FilterRepository<Bicycle>>();
            services.AddScoped<FilterRepository<Mountain>>();
            services.AddScoped<FilterRepository<Highway>>();
            services.AddScoped<FilterRepository<Gravel>>();
            services.AddScoped<FilterRepository<Electro>>();
        }

        public static void ConfigureBicycleServiceManager(this IServiceCollection services)
        {
            services.AddScoped<IBicycleService<Bicycle>, BicycleService<Bicycle>>();
            services.AddScoped<IBicycleService<Mountain>, BicycleService<Mountain>>();
            services.AddScoped<IBicycleService<Highway>, BicycleService<Highway>>();
            services.AddScoped<IBicycleService<Gravel>, BicycleService<Gravel>>();
            services.AddScoped<IBicycleService<Electro>, BicycleService<Electro>>();
        }
    }
}

