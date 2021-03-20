using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();

        IDataResult<List<CustomerDetailDto>> GetCustomerDetails();

        IDataResult<Customer> Get(int id);

        IResult Add(Customer entity);

        IResult Update(Customer entity);

        IResult Delete(Customer entity);
    }
}