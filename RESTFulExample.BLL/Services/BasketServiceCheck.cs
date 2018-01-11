
using RESTFulExample.BLL.Infrastructure;
using System.Threading.Tasks;

namespace RESTFulExample.BLL.Services
{
    public partial class BasketService
    {
        private async Task CheckEmp(int? employeeId)
        {
            if (employeeId == null)
            {
                throw new BusinessLogicException("Требуется клиент", "");
            }

            var empIsExist = await unitOfWork.Employees.IsExistAsync(where: q => q.Id == employeeId);

            if (!empIsExist)
            {
                throw new BusinessLogicException("Клиент не найден", "");
            }
        }

        private async Task CheckAir(string airId)
        {
            if (airId == null)
            {
                throw new BusinessLogicException("Требуется перелёт", "");
            }

            var airIsExist = await unitOfWork.Airs.IsExistAsync(where: q => q.Id == airId);

            if (!airIsExist)
            {
                throw new BusinessLogicException("Перелёт не найден", "");
            }
        }

        private async Task CheckTrain(string trainId)
        {
            if (trainId == null)
            {
                throw new BusinessLogicException("Требуется поезд", "");
            }

            var trainIsExist = await unitOfWork.Trains.IsExistAsync(where: q => q.Id == trainId);

            if (!trainIsExist)
            {
                throw new BusinessLogicException("Поезд не найден", "");
            }
        }

        private async Task CheckHotel(string hotelId)
        {
            if (hotelId == null)
            {
                throw new BusinessLogicException("Требуется отель", "");
            }

            var hotelIsExist = await unitOfWork.Hotels.IsExistAsync(where: q => q.Id == hotelId);

            if (!hotelIsExist)
            {
                throw new BusinessLogicException("Отель не найден", "");
            }
        }

        private async Task CheckBasket(int? basketId)
        {
            if (basketId == null)
            {
                throw new BusinessLogicException("Требуется заказ", "");
            }

            var basketIsExist = await unitOfWork.Baskets.IsExistAsync(where: q => q.Id == basketId);

            if (!basketIsExist)
            {
                throw new BusinessLogicException("заказ не найден", "");
            }
        }
    }
}
