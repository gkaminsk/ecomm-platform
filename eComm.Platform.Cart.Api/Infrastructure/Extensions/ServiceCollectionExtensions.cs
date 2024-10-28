using CartService.Api.Infrastructure.HttpCommunication;
using CartService.Api.Infrastructure.HttpCommunication.Abstractions;
using CartService.Api.Infrastructure.Options;

namespace CartService.Api.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            var productServiceAddress = configuration.GetValue<string>($"{nameof(AppSettings)}:{nameof(ProductServiceOptions)}:{nameof(ProductServiceOptions.ServiceAddress)}");
            var inventoryServiceAddress = configuration.GetValue<string>($"{nameof(AppSettings)}:{nameof(InventoryServiceOptions)}:{nameof(InventoryServiceOptions.ServiceAddress)}");

            services.AddHttpClient<IProductServiceHttpClient, ProductServiceHttpClient>(client =>
            {
                client.BaseAddress = new Uri(productServiceAddress);
            });

            services.AddHttpClient<IInventoryServiceHttpClient, InventoryServiceHttpClient>(client =>
            {
                client.BaseAddress = new Uri(inventoryServiceAddress);
            });

            return services;
        }
    }
}