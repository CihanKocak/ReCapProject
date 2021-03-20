using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer entity)
        {
            try
            {
                _customerDal.Add(entity);
                return new SuccessResult(Messages.AddCustomerMessage);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.ErrorCustomerFKMessage);
            }
        }

        public IResult Delete(Customer entity)
        {
            _customerDal.Delete(entity);
            return new SuccessResult(Messages.DeleteCustomerMessage);
        }

        public IDataResult<Customer> Get(int id)
        {
            Customer customer = _customerDal.Get(p => p.Id == id);
            if (customer == null)
            {
                return new ErrorDataResult<Customer>(Messages.GetErrorCustomerMessage);
            }
            else
            {
                return new SuccessDataResult<Customer>(customer, Messages.GetSuccessCustomerMessage);
            }
        }

        public IDataResult<List<Customer>> GetAll()
        {
            List<Customer> customers = _customerDal.GetAll();
            if (customers.Count == 0)
            {
                return new ErrorDataResult<List<Customer>>(Messages.GetErrorCustomerMessage);
            }
            else
            {
                return new SuccessDataResult<List<Customer>>(customers, Messages.GetSuccessCustomerMessage);
            }
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetailDto(), Messages.GetSuccessCustomerMessage);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer entity)
        {
            try
            {
                _customerDal.Update(entity);
                return new SuccessResult(Messages.EditCustomerMessage);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.ErrorCustomerFKMessage);
            }
        }
    }
}