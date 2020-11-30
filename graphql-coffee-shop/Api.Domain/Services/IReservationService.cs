using System.Collections.Generic;
using System.Threading.Tasks;
using Teqniqly.Samples.Graphql.CoffeeShop.Models;

namespace Teqniqly.Samples.Graphql.CoffeeShop.Services
{
    public interface IReservationService
    {
        Task<IEnumerable<IReservation>> GetReservationsAsync();
        Task<IReservation> AddReservationAsync(IReservation reservationModel);

        Task<IReservation> DeleteReservationAsync(int id);
    }
}