using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Utilities.Results;
using Data_Access.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfImageLimitExceeded(carImage.CarId));
            if (result == null)
            {
                carImage.Date = DateTime.Now;
                _carImageDal.Add(carImage);
                return new SuccessResult(Messages.CarImageAdded);
            }
            return new ErrorResult(Messages.CarImageNotAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }


        public IDataResult<List<CarImage>> GetAll(Expression<Func<CarImage, bool>> filter = null)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImagesListed);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            var result = _carImageDal.GetAll(c => c.CarId == id);
            if (result.Any())
            {
                return new SuccessDataResult<List<CarImage>>(result, Messages.CarImagesListed);
            }
            return new SuccessDataResult<List<CarImage>>(new List<CarImage>
                {
                    new CarImage{ ImagePath = "default.jpg", Date = DateTime.Now }
                });
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            var entity = _carImageDal.Get(ci => ci.Id == carImage.Id);
            if (entity != null)
            {
                entity.ImagePath = carImage.ImagePath;
                entity.Date = DateTime.Now;
                _carImageDal.Update(entity);
                return new SuccessResult(Messages.CarImageUpdated);
            }
            return new ErrorResult(Messages.CarImageNotFound);
        }

        private IResult CheckIfImageLimitExceeded(int id)
        {
            var countOfImages = _carImageDal.GetAll(c => c.CarId == id).Count;
            if (countOfImages < 5)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CarImageCountExceeded);
        }
    }
}
