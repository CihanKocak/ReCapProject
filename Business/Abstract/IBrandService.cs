using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();

        IDataResult<Brand> Get(int id);

        IResult Add(Brand entity);

        IResult Update(Brand entity);

        IResult Delete(Brand entity);
    }
}
