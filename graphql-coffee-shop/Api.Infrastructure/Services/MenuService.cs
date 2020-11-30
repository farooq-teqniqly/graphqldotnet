using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Teqniqly.Samples.Graphql.CoffeeShop.Dtos;
using Teqniqly.Samples.Graphql.CoffeeShop.Models;

namespace Teqniqly.Samples.Graphql.CoffeeShop.Services
{
    public class MenuService : ServiceBase, IMenuService
    {
        public MenuService(IDataStoreService dataStoreService, IMapper mapper) : base(dataStoreService, mapper)
        {
        }

        public async Task<IEnumerable<IMenu>> GetMenusAsync()
        {
            var dtos = await DataStoreService.GetAllAsync<MenuDto>();
            var models = Mapper.Map<IEnumerable<MenuModel>>(dtos);
            return models;
        }

        public async Task<IMenu> AddMenuAsync(IMenu menuModel)
        {
            var menuDto = Mapper.Map<MenuDto>(menuModel);
            var subMenuDtos = Mapper.Map<SubMenuDto[]>(menuModel.SubMenus);
            menuDto.SubMenus = subMenuDtos;
            var insertedDto = await DataStoreService.InsertAsync(menuDto);
            var insertedModel = Mapper.Map<MenuModel>(insertedDto);
            return insertedModel;
        }

        public async Task<IMenu> DeleteMenuAsync(int id)
        {
            var dtoToDelete = await DataStoreService.FindAsync<MenuDto>(id);

            if (dtoToDelete == null)
            {
                return null;
            }

            var deletedDto = await DataStoreService.DeleteAsync<MenuDto>(id);
            var model = Mapper.Map<MenuModel>(deletedDto);
            return model;
        }

        public async Task<IMenu> GetMenuAsync(int id)
        {
            var menuDto = await DataStoreService.FindAsync<MenuDto>(id);
            var subMenuDtos = (await DataStoreService.GetAllAsync<SubMenuDto>()).Where(sm => sm.Menu.Id == id);

            var subMenuModels = Mapper.Map<IEnumerable<SubMenuModel>>(subMenuDtos);
            var menuModel = Mapper.Map<MenuModel>(menuDto);
            menuModel.SubMenus = subMenuModels.ToArray();

            return menuModel;
        }
    }
}
