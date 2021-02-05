using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Color color)
        {
            _colorDal.Add(color);
            Console.WriteLine("Renk başarıyla eklendi!");
        }

        public void Delete(Color color)
        {
            _colorDal.Delete(color);
            Console.WriteLine("Renk başarıyla silindi!");
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public List<Color> GetByColorId(int colorId)
        {
            return _colorDal.GetAll(c => c.ColorId == colorId);
        }

        public void Update(Color color)
        {
            _colorDal.Update(color);
            Console.WriteLine("Renk başarıyla güncellendi!");
        }
    }
}
