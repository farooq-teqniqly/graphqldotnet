using System.Collections.Generic;
using System.Threading.Tasks;
using Teqniqly.Samples.Graphql.CoffeeShop.Models;

namespace Teqniqly.Samples.Graphql.CoffeeShop.Services
{
    public interface IMenuService
    {
        Task<IEnumerable<IMenu>> GetsMenusAsync();
        Task<IMenu> AddMenuAsync(IMenu menuModel);

        Task<IMenu> DeleteMenuAsync(int id);
    }
}
