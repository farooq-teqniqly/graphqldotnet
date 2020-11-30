using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Teqniqly.Samples.Graphql.CoffeeShop.Models;
using Xunit;

namespace Api.Infrastructure.IntegrationTests
{
    public class MenuServiceIntegrationTests : IntegrationTest
    {
        [Fact]
        public async Task Create_Menus_With_Submenus()
        {
            var expectedMenu = DefaultMenuModel;
            IMenu actualMenu = null;

            try
            {
                actualMenu = await MenuService.AddMenuAsync(expectedMenu);

                actualMenu.Id.Should().BeGreaterThan(0);
                actualMenu.Name.Should().Be(expectedMenu.Name);
                actualMenu.Image.Should().Be(expectedMenu.Image);
                actualMenu.SubMenus.Count.Should().Be(2);

                foreach (var subMenu in actualMenu.SubMenus)
                {
                    subMenu.Id.Should().BeGreaterThan(0);
                    subMenu.Name.Should().Be(subMenu.Name);
                    subMenu.Description.Should().Be(subMenu.Description);
                    subMenu.Price.Should().Be(subMenu.Price);
                    subMenu.Menu.Should().BeEquivalentTo(actualMenu);
                }
            }
            finally
            {
                await MenuService.DeleteMenuAsync(actualMenu.Id);
            }
        }

        [Fact]
        public async Task GetMenus()
        {
            var menuIds = new List<int>();

            try
            {
                menuIds = new List<int>
                {
                    (await MenuService.AddMenuAsync(DefaultMenuModel)).Id,
                    (await MenuService.AddMenuAsync(CreateMenuWithName("Teas"))).Id
                };


                var actualMenus = (await MenuService.GetsMenusAsync())
                    .Where(m => menuIds.Contains(m.Id))
                    .ToList();

                actualMenus.Count.Should().Be(2);
            }
            finally
            {
                foreach (var menuId in menuIds)
                {
                    await MenuService.DeleteMenuAsync(menuId);
                }
            }
        }
    }
}
