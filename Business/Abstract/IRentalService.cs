using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();

        IDataResult<Rental> Get(int id);

        IResult Add(Rental entity);

        IResult Update(Rental entity);

        IResult Delete(Rental entity);

        /// <summary>
        /// Aracı teslim al.
        /// </summary>
        IResult DeliverTheCar(Rental rental);

        /// <summary>
        /// Kiralanan ve kiralanmayan tüm araçların detaylı listesidir.
        /// </summary>
        IDataResult<List<RentalDetailDto>> GetAllRentalDetails();

        /// <summary>
        /// Teslim alınmayan tüm araçların detaylı listesidir.
        /// </summary>
        IDataResult<List<RentalDetailDto>> GetAllUndeliveredRentalDetails();

        /// <summary>
        /// Teslim alınan tüm araçların detaylı listesidir.
        /// </summary>
        IDataResult<List<RentalDetailDto>> GetAllDeliveredRentalDetails();
    }
}