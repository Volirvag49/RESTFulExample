
using RESTFulExample.BLL.Infrastructure;
using System.Threading.Tasks;

namespace RESTFulExample.BLL.Services
{
    public partial class CartService
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
                throw new BusinessLogicException("Требуется услуга", "");
            }

            var airIsExist = await unitOfWork.Airs.IsExistAsync(where: q => q.Id == airId || q.TravellerId == null);

            if (!airIsExist)
            {
                throw new BusinessLogicException("услуга не найдена", "");
            }

        }

        private async Task CheckTrain(string trainId)
        {
            if (trainId == null)
            {
                throw new BusinessLogicException("Требуется услуга", "");
            }

            var trainIsExist = await unitOfWork.Trains.IsExistAsync(where: q => q.Id == trainId || q.TravellerId == null);

            if (!trainIsExist)
            {
                throw new BusinessLogicException("услуга не найдена", "");
            }
        }

        private async Task CheckHotel(string hotelId)
        {
            if (hotelId == null)
            {
                throw new BusinessLogicException("Требуется услуга", "");
            }

            var hotelIsExist = await unitOfWork.Hotels.IsExistAsync(where: q => q.Id == hotelId || q.TravellerId == null);

            if (!hotelIsExist)
            {
                throw new BusinessLogicException("Услуга не найден", "");
            }
        }

        private async Task CheckCart(int? basketId)
        {
            if (basketId == null)
            {
                throw new BusinessLogicException("Требуется услуга", "");
            }

            var basketIsExist = await unitOfWork.Carts.IsExistAsync(where: q => q.Id == basketId);

            if (!basketIsExist)
            {
                throw new BusinessLogicException("Услуга не найдена", "");
            }
        }
    }
}
