using AutoMapper;
using GraphiQl;
using GraphQL.Execution;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Teqniqly.Samples.Graphql.CoffeeShop.Dtos;
using Teqniqly.Samples.Graphql.CoffeeShop.Models;
using Teqniqly.Samples.Graphql.CoffeeShop.Mutations;
using Teqniqly.Samples.Graphql.CoffeeShop.Queries;
using Teqniqly.Samples.Graphql.CoffeeShop.Schemas;
using Teqniqly.Samples.Graphql.CoffeeShop.Services;
using Teqniqly.Samples.Graphql.CoffeeShop.Types;

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
                    options.EnableMetrics = true;
                    options.UnhandledExceptionDelegate = context => throw new UnhandledError(context.ErrorMessage, context.OriginalException);
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

            services.AddScoped<MenuType>();
            services.AddScoped<MenuSummaryType>();
            services.AddScoped<SubMenuType>();
            services.AddScoped<ReservationType>();
            services.AddScoped<MenuInputType>();
            services.AddScoped<SubMenuInputType>();
            services.AddScoped<InputObjectGraphType<ListGraphType<SubMenuInputType>>>();
            services.AddScoped<MenuQuery>();
            services.AddScoped<MenusQuery>();
            services.AddScoped<ReservationQuery>();
            services.AddScoped<RootQuery>();
            services.AddScoped<MenuMutation>();
            services.AddScoped<RootMutation>();
            services.AddScoped<ISchema, RootSchema>();

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
