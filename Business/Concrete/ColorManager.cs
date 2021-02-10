using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager:IColorService
    {

        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }


        public void Add(Color color)
        {

            try
            {
                _colorDal.Add(color);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine(color.Name + " isminde renk zaten var, aynı rengi ekleyemezsiniz");
            }

        }

        public void Delete(Color color)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetAll()
        {
            throw new NotImplementedException();
        }

        public Color GetByColorId(int colorId)
        {
            throw new NotImplementedException();
        }

        public void Update(Color color)
        {
            throw new NotImplementedException();
        }

    }
}
