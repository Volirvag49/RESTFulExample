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
    public partial class BasketService :IBasketService
    {
        IUnitOfWork unitOfWork { get; set; }

        public BasketService(IUnitOfWork uow)
        {
            this.unitOfWork = uow;
        }

        public async Task<IEnumerable> FindByEmpIdAsync(int? id)
        {
            if (id == null)
            {
                throw new BusinessLogicException("Требуется Клиент", "");
            }

            Expression<Func<Basket, bool>> searchQuery = q => q.EmployeeId == id;

            var baskets = await  Mapper.Map<Task<IEnumerable<Basket>>, Task<IEnumerable<BasketDTO>>>(unitOfWork.Baskets.GetAsync(filter: searchQuery));

            return baskets;
        }

        public async Task AddAirAsync(int? employeeId, string airId)
        {
            await CheckEmp(employeeId);
            await CheckAir(airId);

            Basket newbasket = new Basket() { EmployeeId= employeeId, AirId = airId};

            await unitOfWork.Baskets.CreateAsync(newbasket);
        }

        public async Task AddTrainAsync(int? employeeId, string trainId)
        {
            await CheckEmp(employeeId);
            await CheckTrain(trainId);

            Basket newbasket = new Basket() { EmployeeId = employeeId, TrainId = trainId };

            await unitOfWork.Baskets.CreateAsync(newbasket);
        }

        public async Task AddHotelAsync(int? employeeId, string hotelId)
        {
            await CheckEmp(employeeId);
            await CheckHotel(hotelId);

            Basket newbasket = new Basket() { EmployeeId = employeeId, HotelId = hotelId };

            await unitOfWork.Baskets.CreateAsync(newbasket);
        }      

        public async Task DeleteAsync(int? BasketId)
        {
            await CheckBasket(BasketId);

            var basket = await unitOfWork.Baskets.GetByIdAsynс(BasketId);

            await unitOfWork.Baskets.DeleteAsync(basket);
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
