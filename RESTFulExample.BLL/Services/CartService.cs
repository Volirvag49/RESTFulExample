using AutoMapper;
using RESTFulExample.BLL.DTO;
using RESTFulExample.BLL.Infrastructure;
using RESTFulExample.BLL.Interfaces;
using RESTFulExample.DAL.Entities;
using RESTFulExample.DAL.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RESTFulExample.BLL.Services
{
    public partial class CartService : ICartService
    {
        IUnitOfWork unitOfWork { get; set; }

        public CartService(IUnitOfWork uow)
        {
            this.unitOfWork = uow;
        }

        public async Task<IEnumerable<OrderDTO>> FindByIdEmpAsync(int? employeeId)
        {
            if (employeeId == null)
            {
                throw new BusinessLogicException("Требуется Клиент", "");
            }

            Cart cart = await unitOfWork.Carts.GetByAsync(x => x.EmployeeId == employeeId);

            var orders = await unitOfWork.Orders.GetAsync(filter: q => q.CartId == cart.Id);

            var ordersDTO = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(orders);

            return ordersDTO;
        }

        public async Task AddAirAsync(ServiceDTO services)
        {

            await CheckEmp(services.EmployeeId);

            Cart cart = await unitOfWork.Carts.GetByAsync(x => x.EmployeeId == services.EmployeeId);

            foreach (var item in services.serviceIds)
            {
                await CheckAir(item);



                Air air = await unitOfWork.Airs.GetByIdAsynс(item);
                air.TravellerId = services.EmployeeId;

                Order newOrder = new Order() { CartId = cart.Id, ServiceId = item, ServiceTipe = ServiceTipe.Air };
                unitOfWork.Orders.Create(newOrder);
            }

            await unitOfWork.CommitAsync();
        }

        public async Task AddTrainAsync(ServiceDTO services)
        {
            await CheckEmp(services.EmployeeId);

            Cart cart = await unitOfWork.Carts.GetByAsync(x => x.EmployeeId == services.EmployeeId);

            foreach (var item in services.serviceIds)
            {
                await CheckTrain(item);

                Train train = await unitOfWork.Trains.GetByIdAsynс(item);
                train.TravellerId = services.EmployeeId;

                Order newOrder = new Order() { CartId = cart.Id, ServiceId = item, ServiceTipe = ServiceTipe.Train };
                unitOfWork.Orders.Create(newOrder);
            }

            await unitOfWork.CommitAsync();
        }


        public async Task AddHotelAsync(ServiceDTO services)
        {
            await CheckEmp(services.EmployeeId);

            Cart cart = await unitOfWork.Carts.GetByAsync(x => x.EmployeeId == services.EmployeeId);

            foreach (var item in services.serviceIds)
            {
                await CheckHotel(item);

                Hotel hotel = await unitOfWork.Hotels.GetByIdAsynс(item);
                hotel.TravellerId = services.EmployeeId;

                Order newOrder = new Order() { CartId = cart.Id, ServiceId = item, ServiceTipe = ServiceTipe.Hotel };
                unitOfWork.Orders.Create(newOrder);
            }

            await unitOfWork.CommitAsync();
        }


        public async Task DeleteAsync(int? cartId)
        {
            await CheckCart(cartId);

            IEnumerable<Order> orders = await unitOfWork.Orders.GetAsync(x => x.CartId == cartId);

            foreach (var item in orders)
            {
                if (item.ServiceTipe == ServiceTipe.Air)
                {
                    Air air = await unitOfWork.Airs.GetByIdAsynс(item.ServiceId);

                    air.TravellerId = null;
                    unitOfWork.Airs.Update(air);
                    unitOfWork.Orders.Delete(item);

                }

                if (item.ServiceTipe == ServiceTipe.Train)
                {
                    Train train = await unitOfWork.Trains.GetByIdAsynс(item.ServiceId);

                    train.TravellerId = null;
                    unitOfWork.Trains.Update(train);

                    unitOfWork.Orders.Delete(item);

                }

                if (item.ServiceTipe == ServiceTipe.Hotel)
                {
                    Hotel hotel = await unitOfWork.Hotels.GetByIdAsynс(item.ServiceId);

                    hotel.TravellerId = null;
                    unitOfWork.Hotels.Update(hotel);

                    unitOfWork.Orders.Delete(item);

                }

                await unitOfWork.CommitAsync();

            }

        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
