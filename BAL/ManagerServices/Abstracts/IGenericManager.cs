using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BAL.ManagerServices.Abstracts
{
    public interface IGenericManager<T> where T : class
    {
        // Modify
        void TInsert(T t);
        void TDelete(T t);
        void TUpdate(T t);
        // List
        List<T> TGetList();
        List<T> TGetAllWithFilter(Expression<Func<T, bool>> filter);
        // Find
        T TFindById(int id);
    }
}
