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
        IUnitOfWork _unitOfWork { get; set; }

        public CartService(IUnitOfWork uow)
        {
            this._unitOfWork = uow;
        }

        public async Task<IEnumerable<OrderDTO>> FindByIdEmpAsync(int? employeeId)
        {
            if (employeeId == null)
            {
                throw new BusinessLogicException("Требуется Клиент", "");
            }

            Cart cart = await _unitOfWork.Carts.GetByAsync(x => x.EmployeeId == employeeId);

            var orders = await _unitOfWork.Orders.GetAsync(filter: q => q.CartId == cart.Id);

            var ordersDTO = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(orders);

            return ordersDTO;
        }

        public async Task AddAirAsync(ServiceDTO services)
        {

            await CheckEmp(services.EmployeeId);

            Cart cart = await _unitOfWork.Carts.GetByAsync(x => x.EmployeeId == services.EmployeeId);

            foreach (var item in services.serviceIds)
            {
                await CheckAir(item);



                Air air = await _unitOfWork.Airs.GetByIdAsynс(item);
                air.TravellerId = services.EmployeeId;

                Order newOrder = new Order() { CartId = cart.Id, ServiceId = item, ServiceTipe = ServiceTipe.Air };
                _unitOfWork.Orders.Create(newOrder);
            }

            await _unitOfWork.CommitAsync();
        }

        public async Task AddTrainAsync(ServiceDTO services)
        {
            await CheckEmp(services.EmployeeId);

            Cart cart = await _unitOfWork.Carts.GetByAsync(x => x.EmployeeId == services.EmployeeId);

            foreach (var item in services.serviceIds)
            {
                await CheckTrain(item);

                Train train = await _unitOfWork.Trains.GetByIdAsynс(item);
                train.TravellerId = services.EmployeeId;

                Order newOrder = new Order() { CartId = cart.Id, ServiceId = item, ServiceTipe = ServiceTipe.Train };
                _unitOfWork.Orders.Create(newOrder);
            }

            await _unitOfWork.CommitAsync();
        }


        public async Task AddHotelAsync(ServiceDTO services)
        {
            await CheckEmp(services.EmployeeId);

            Cart cart = await _unitOfWork.Carts.GetByAsync(x => x.EmployeeId == services.EmployeeId);

            foreach (var item in services.serviceIds)
            {
                await CheckHotel(item);

                Hotel hotel = await _unitOfWork.Hotels.GetByIdAsynс(item);
                hotel.TravellerId = services.EmployeeId;

                Order newOrder = new Order() { CartId = cart.Id, ServiceId = item, ServiceTipe = ServiceTipe.Hotel };
                _unitOfWork.Orders.Create(newOrder);
            }

            await _unitOfWork.CommitAsync();
        }


        public async Task DeleteAllAsync(int? cartId)
        {
            await CheckCart(cartId);

            IEnumerable<Order> orders = await _unitOfWork.Orders.GetAsync(x => x.CartId == cartId);

            foreach (var item in orders)
            {
                if (item.ServiceTipe == ServiceTipe.Air)
                {
                    Air air = await _unitOfWork.Airs.GetByIdAsynс(item.ServiceId);

                    air.TravellerId = null;
                    _unitOfWork.Airs.Update(air);
                    _unitOfWork.Orders.Delete(item);

                }

                if (item.ServiceTipe == ServiceTipe.Train)
                {
                    Train train = await _unitOfWork.Trains.GetByIdAsynс(item.ServiceId);

                    train.TravellerId = null;
                    _unitOfWork.Trains.Update(train);

                    _unitOfWork.Orders.Delete(item);

                }

                if (item.ServiceTipe == ServiceTipe.Hotel)
                {
                    Hotel hotel = await _unitOfWork.Hotels.GetByIdAsynс(item.ServiceId);

                    hotel.TravellerId = null;
                    _unitOfWork.Hotels.Update(hotel);

                    _unitOfWork.Orders.Delete(item);

                }

                await _unitOfWork.CommitAsync();

            }

        }

        public async Task DeleteAsync(string serviceId)
        {

            Order order = await _unitOfWork.Orders.GetByAsync(x => x.ServiceId == serviceId);

            if (order.ServiceTipe == ServiceTipe.Air)
            {
                Air air = await _unitOfWork.Airs.GetByIdAsynс(order.ServiceId);

                air.TravellerId = null;
                _unitOfWork.Airs.Update(air);
                _unitOfWork.Orders.Delete(order);

            }

            if (order.ServiceTipe == ServiceTipe.Train)
            {
                Train train = await _unitOfWork.Trains.GetByIdAsynс(order.ServiceId);

                train.TravellerId = null;
                _unitOfWork.Trains.Update(train);

                _unitOfWork.Orders.Delete(order);

            }

            if (order.ServiceTipe == ServiceTipe.Hotel)
            {
                Hotel hotel = await _unitOfWork.Hotels.GetByIdAsynс(order.ServiceId);

                hotel.TravellerId = null;
                _unitOfWork.Hotels.Update(hotel);

                _unitOfWork.Orders.Delete(order);

            }

            await _unitOfWork.CommitAsync();
        
        }
      
        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
