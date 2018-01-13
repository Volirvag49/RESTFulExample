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

        public async Task<IEnumerable<CartDTO>> FindByIdAsync(int? employeeId)
        {
            if (employeeId == null)
            {
                throw new BusinessLogicException("Требуется Клиент", "");
            }

            Expression<Func<Cart, bool>> searchQuery = q => q.EmployeeId == employeeId;

            var orders = await Mapper.Map<Task<IEnumerable<Cart>>, Task<IEnumerable<CartDTO>>>(unitOfWork.Carts.GetAsync(filter: searchQuery));

            return orders;
        }

        public async Task AddAirAsync(int? employeeId, string airId)
        {
            await CheckEmp(employeeId);
            await CheckAir(airId);

            Cart newbasket = new Cart() { EmployeeId = employeeId, AirId = airId };

            unitOfWork.Carts.Create(newbasket);
            await unitOfWork.CommitAsync();
        }

        public async Task AddTrainAsync(int? employeeId, string trainId)
        {
            await CheckEmp(employeeId);
            await CheckTrain(trainId);

            Cart newCart = new Cart() { EmployeeId = employeeId, TrainId = trainId };

            unitOfWork.Carts.Create(newCart);
            await unitOfWork.CommitAsync();
        }

        public async Task AddHotelAsync(int? employeeId, string hotelId)
        {
            await CheckEmp(employeeId);
            await CheckHotel(hotelId);

            Cart newCart = new Cart() { EmployeeId = employeeId, HotelId = hotelId };

            unitOfWork.Carts.Create(newCart);
            await unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int? cartId)
        {
            await CheckCart(cartId);

            var cart = await unitOfWork.Carts.GetByIdAsynс(cartId);

            unitOfWork.Carts.Delete(cart);
            await unitOfWork.CommitAsync();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
