using Microsoft.EntityFrameworkCore;
using Teqniqly.Samples.Graphql.Dtos;

namespace Teqniqly.Samples.Graphql
{
    public class GraphqlDbContext : DbContext
    {
        public GraphqlDbContext(DbContextOptions<GraphqlDbContext> options) : base(options)
        {
        }

        public DbSet<ProductDto> ProductDtos { get; set; }
    }
}
