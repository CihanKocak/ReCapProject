using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        //[SecuredOperation("brand")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand entity)
        {
            _brandDal.Add(entity);
            return new SuccessResult(Messages.AddBrandMessage);
        }

        public IResult Delete(Brand entity)
        {
            _brandDal.Delete(entity);
            return new SuccessResult(Messages.DeleteBrandMessage);
        }

        public IDataResult<Brand> Get(int id)
        {
            Brand brand = _brandDal.Get(p => p.BrandId == id);

            if (brand == null)
            {
                return new ErrorDataResult<Brand>(Messages.GetErrorBrandMessage);
            }
            else
            {
                return new SuccessDataResult<Brand>(brand, Messages.GetSuccessBrandMessage);
            }
        }

        //[SecuredOperation("brand")]
        public IDataResult<List<Brand>> GetAll()
        {
            List<Brand> brands = _brandDal.GetAll();
            if (brands == null)
            {
                return new ErrorDataResult<List<Brand>>(Messages.GetErrorBrandMessage);
            }
            else
            {
                return new SuccessDataResult<List<Brand>>(brands, Messages.GetSuccessBrandMessage);
            }
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.EditBrandMessage);
        }
    }
}