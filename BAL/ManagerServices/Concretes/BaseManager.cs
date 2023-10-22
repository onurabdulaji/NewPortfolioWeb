using BAL.ManagerServices.Abstracts;
using DAL.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BAL.ManagerServices.Concretes
{
    public class BaseManager<T> : IGenericManager<T> where T : class
    {
        protected IGenericDal<T> _generIGenericDal;

        public BaseManager(IGenericDal<T> generIGenericDal)
        {
            _generIGenericDal = generIGenericDal;
        }

        public void TDelete(T t)
        {
            _generIGenericDal.Delete(t);
        }

        public T TFindById(int id)
        {
            return _generIGenericDal.FindById(id);
        }

        public List<T> TGetAllWithFilter(Expression<Func<T, bool>> filter)
        {
            return _generIGenericDal.GetAllWithFilter(filter);
        }

        public List<T> TGetList()
        {
            return _generIGenericDal.GetList();
        }

        public void TInsert(T t)
        {
            _generIGenericDal.Insert(t);
        }

        public void TUpdate(T t)
        {
            _generIGenericDal.Update(t);
        }
    }
}
