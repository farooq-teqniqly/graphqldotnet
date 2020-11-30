using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Teqniqly.Samples.Graphql.CoffeeShop;
using Teqniqly.Samples.Graphql.CoffeeShop.Dtos;
using Teqniqly.Samples.Graphql.CoffeeShop.Models;
using Teqniqly.Samples.Graphql.CoffeeShop.Services;

namespace Api.Infrastructure.IntegrationTests
{
    public abstract class IntegrationTest : IDisposable
    {
        private bool _disposed = false;

        public IMenuService MenuService { get; }
        public IReservationService ReservationService { get; }

        protected IMenu DefaultMenuModel => new MenuModel
        {
            Name = "Coffees",
            Image = "image001.jpg",
            SubMenus = new List<ISubMenu>
            {
                new SubMenuModel
                {
                    Name = "Ethiopian",
                    Description = "Ethiopian coffee",
                    Price = 11.95m
                },
                new SubMenuModel
                {
                    Name = "Dark roast",
                    Description = "Dark roast coffee",
                    Price = 6.95m
                }
            }
        };

        protected IReservation DefaultReservationModel => new ReservationModel
        {
            Name = "reservation1",
            Email = "foo@bar.com",
            Phone = "(205)-555-9999",
            TotalPeople = 5,
            DateAndTime = DateTime.Parse("12/1/2020 18:00:00")
        };

        protected IntegrationTest()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            var options = new DbContextOptionsBuilder<GraphqlDbContext>()
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .Options;
            
            var dbContext = new GraphqlDbContext(options);
            var dataStoreService = new EntityFrameworkDataStoreService(dbContext);

            var mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<MenuModel, MenuDto>().ReverseMap();
                config.CreateMap<SubMenuModel, SubMenuDto>().ReverseMap();
                config.CreateMap<ReservationModel, ReservationDto>().ReverseMap();
            });

            mapperConfig.AssertConfigurationIsValid();
            var mapper = mapperConfig.CreateMapper();

            MenuService = new MenuService(dataStoreService, mapper);
            ReservationService = new ReservationService(dataStoreService, mapper);
        }

        protected IMenu CreateMenuWithName(string name)
        {
            var copy = DefaultMenuModel;
            copy.Name = name;
            return copy;
        }

        protected IReservation CreateReservationWithName(string name)
        {
            var copy = DefaultReservationModel;
            copy.Name = name;
            return copy;
        }

        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                ((IDisposable)MenuService).Dispose();
                ((IDisposable)ReservationService).Dispose();
            }

            _disposed = true;
        }
    }
}
