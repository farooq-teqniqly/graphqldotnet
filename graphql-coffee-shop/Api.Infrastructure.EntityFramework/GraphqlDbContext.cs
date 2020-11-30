using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Teqniqly.Samples.Graphql.CoffeeShop.Dtos;

namespace Teqniqly.Samples.Graphql.CoffeeShop
{
    public class GraphqlDbContext : DbContext
    {
        public GraphqlDbContext(DbContextOptions<GraphqlDbContext> options) : base(options)
        {
            
        }

        public DbSet<MenuDto> MenuDtos { get; set; }
        public DbSet<SubMenuDto> SubMenuDtos { get; set; }
        public DbSet<ReservationDto> ReservationDtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubMenuDto>()
                .HasOne(dto => (MenuDto) dto.Menu)
                .WithMany(m => (IEnumerable<SubMenuDto>) m.SubMenus)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
