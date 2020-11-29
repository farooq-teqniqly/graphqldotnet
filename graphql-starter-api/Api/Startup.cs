using GraphiQl;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Teqniqly.Samples.Graphql.Mutations;
using Teqniqly.Samples.Graphql.Queries;
using Teqniqly.Samples.Graphql.Schemas;
using Teqniqly.Samples.Graphql.Services;
using Teqniqly.Samples.Graphql.Types;

namespace Teqniqly.Samples.Graphql
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
            services.AddControllers();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IDataStoreService, EntityFrameworkDataStoreService>();
            services.AddScoped<ProductType>();
            services.AddScoped<ProductQuery>();
            services.AddScoped<ProductMutation>();
            services.AddScoped<ISchema, ProductSchema>();

            services.AddGraphQL(options =>
            {
                options.EnableMetrics = false;
            })
                .AddSystemTextJson();

            services.AddDbContext<GraphqlDbContext>(options =>
                options.UseSqlServer(
                    @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=graphql-products;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
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
