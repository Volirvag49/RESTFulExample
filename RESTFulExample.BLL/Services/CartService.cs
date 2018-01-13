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

        public async Task<IEnumerable<CartDTO>> FindByIdEmpAsync(int? employeeId)
        {
            if (employeeId == null)
            {
                throw new BusinessLogicException("Требуется Клиент", "");
            }

            Expression<Func<Cart, bool>> searchQuery = q => q.EmployeeId == employeeId;

            var orders = await Mapper.Map<Task<IEnumerable<Cart>>, Task<IEnumerable<CartDTO>>>(unitOfWork.Carts.GetAsync(filter: searchQuery));

            return orders;
        }
        
        public async Task AddAirAsync(ServiceDTO services)
        {
            await CheckEmp(services.EmployeeId);

            foreach (var item in  services.serviceIds)
            {
                await CheckAir(item);

                Air air = await unitOfWork.Airs.GetByIdAsynс(item);
                air.TravellerId = services.EmployeeId;

                Cart newCart = new Cart() { EmployeeId = services.EmployeeId, AirId = item };
                unitOfWork.Carts.Create(newCart);
            }

            await unitOfWork.CommitAsync();
        }

        public async Task AddTrainAsync(ServiceDTO services)
        {
            await CheckEmp(services.EmployeeId);

            foreach (var item in services.serviceIds)
            {
                await CheckTrain(item);

                Train train = await unitOfWork.Trains.GetByIdAsynс(item);
                train.TravellerId = services.EmployeeId;

                Cart newCart = new Cart() { EmployeeId = services.EmployeeId, TrainId = item };
                unitOfWork.Carts.Create(newCart);
            }

            await unitOfWork.CommitAsync();
        }

     
        public async Task AddHotelAsync(ServiceDTO services)
        {
            await CheckEmp(services.EmployeeId);

            foreach (var item in services.serviceIds)
            {
                await CheckHotel(item);

                Hotel hotel = await unitOfWork.Hotels.GetByIdAsynс(item);
                hotel.TravellerId = services.EmployeeId;

                Cart newCart = new Cart() { EmployeeId = services.EmployeeId, HotelId = item };
                unitOfWork.Carts.Create(newCart);
            }

            await unitOfWork.CommitAsync();
        }
      

        public async Task DeleteAsync(int? cartId)
        {
            await CheckCart(cartId);

            Cart cart = await unitOfWork.Carts.GetByIdAsynс(cartId);

            if (cart.AirId != null)
            {
                Air air = await unitOfWork.Airs.GetByIdAsynс(cart.AirId);

                air.TravellerId = null;
                unitOfWork.Airs.Update(air);
            }

            else if (cart.TrainId != null)
            {
                Train train = await unitOfWork.Trains.GetByIdAsynс(cart.TrainId);

                train.TravellerId = null;
                unitOfWork.Trains.Update(train);
            }

            else
            {
                Hotel hotel = await unitOfWork.Hotels.GetByIdAsynс(cart.HotelId);
                hotel.TravellerId = null;
                unitOfWork.Hotels.Update(hotel);
            }

            unitOfWork.Carts.Delete(cart);

            await unitOfWork.CommitAsync();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
