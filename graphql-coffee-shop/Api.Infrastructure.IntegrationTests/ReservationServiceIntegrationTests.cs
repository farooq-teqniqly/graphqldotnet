using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Api.Infrastructure.IntegrationTests
{
    public class ReservationServiceIntegrationTests : IntegrationTest
    {
        [Fact]
        public async Task Create_Reservations()
        {
            var reservationIds = new List<int>();
            
            try
            {
                reservationIds = new List<int>
                {
                    (await ReservationService.AddReservationAsync(DefaultReservationModel)).Id,
                    (await ReservationService.AddReservationAsync(CreateReservationWithName("reservation2"))).Id
                };

                var actualReservations = (await ReservationService.GetReservationsAsync())
                    .Where(r => reservationIds.Contains(r.Id))
                    .ToList();

                actualReservations.Count.Should().Be(2);
            }
            finally
            {
                foreach (var reservationId in reservationIds)
                {
                    await ReservationService.DeleteReservationAsync(reservationId);
                }
            }
        }
    }
}
