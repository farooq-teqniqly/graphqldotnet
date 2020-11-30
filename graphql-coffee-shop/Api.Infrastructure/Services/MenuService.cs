using System.Collections.Generic;
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

        public async Task<IEnumerable<IMenu>> GetsMenusAsync()
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
    }
}
