using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();

        IDataResult<Car> Get(int id);

        IResult Add(Car entity);

        IResult AddTransactionTest(Car entity);

        IResult Update(Car entity);

        IResult Delete(Car entity);
        IDataResult<List<CarDetailDto>> GetCarsDetail();
        IDataResult<List<CarDetailDto>> GetCarsDetailByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarsDetailByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarsDetailByBrandIdAndColorId(int brandId, int colorId);
        IDataResult<CarDetailAndImagesDto> GetCarDetailAndImagesDto(int carId);
    }
}