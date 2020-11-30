using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Teqniqly.Samples.Graphql.CoffeeShop.Dtos;
using Teqniqly.Samples.Graphql.CoffeeShop.Models;

namespace Teqniqly.Samples.Graphql.CoffeeShop.Services
{
    public class ReservationService : ServiceBase, IReservationService
    {
        public ReservationService(IDataStoreService dataStoreService, IMapper mapper) : base(dataStoreService, mapper)
        {
        }

        public async Task<IEnumerable<IReservation>> GetReservationsAsync()
        {
            var dtos = (await DataStoreService.GetAllAsync<ReservationDto>()).ToList();
            var models = Mapper.Map<IEnumerable<ReservationModel>>(dtos);
            return models;
        }

        public async Task<IReservation> AddReservationAsync(IReservation reservationModel)
        {
            var dto = Mapper.Map<ReservationDto>(reservationModel);
            var addedDto = await DataStoreService.InsertAsync(dto);
            var model = Mapper.Map<ReservationModel>(addedDto);
            return model;
        }

        public async Task<IReservation> DeleteReservationAsync(int id)
        {
            var dto = await DataStoreService.FindAsync<ReservationDto>(id);

            if (dto == null)
            {
                return null;
            }

            var deletedDto = await DataStoreService.DeleteAsync<ReservationDto>(id);
            var model = Mapper.Map<ReservationModel>(deletedDto);
            return model;
        }
    }
}
