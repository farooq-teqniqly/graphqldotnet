using AutoMapper;
using GraphiQl;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Teqniqly.Samples.Graphql.CoffeeShop.Dtos;
using Teqniqly.Samples.Graphql.CoffeeShop.Services;

namespace Teqniqly.Samples.Graphql.CoffeeShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGraphQL(options =>
                {
                    options.EnableMetrics = false;
                })
                .AddSystemTextJson();

            services.AddDbContext<GraphqlDbContext>(options =>
                options.UseSqlServer(Configuration["connectionString"]));

            services.AddScoped<IDataStoreService, EntityFrameworkDataStoreService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IReservationService, ReservationService>();

            services.AddAutoMapper(config =>
            {
                config.CreateMap<MenuModel, MenuDto>().ReverseMap();
                config.CreateMap<SubMenuModel, SubMenuDto>().ReverseMap();
                config.CreateMap<ReservationModel, ReservationDto>().ReverseMap();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, GraphqlDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphiQl("/graphql");
            app.UseGraphQL<ISchema>();

            dbContext.Database.EnsureCreated();

        }
    }
}
