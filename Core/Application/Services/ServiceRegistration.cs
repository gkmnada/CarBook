using Application.Features.CQRS.Handlers.AboutHandlers;
using Application.Features.CQRS.Handlers.BannerHandlers;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Services
{
    public static class ServiceRegistration
    {
        public static void ApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(ServiceRegistration).Assembly);

            services.AddScoped<ListAboutQueryHandler>();
            services.AddScoped<GetAboutQueryHandler>();
            services.AddScoped<CreateAboutCommandHandler>();
            services.AddScoped<UpdateAboutCommandHandler>();
            services.AddScoped<DeleteAboutCommandHandler>();

            services.AddScoped<ListBannerQueryHandler>();
            services.AddScoped<GetBannerQueryHandler>();
            services.AddScoped<CreateBannerCommandHandler>();
            services.AddScoped<UpdateBannerCommandHandler>();
            services.AddScoped<DeleteBannerCommandHandler>();
        }
    }
}
