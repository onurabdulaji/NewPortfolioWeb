using EL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Abstracts
{
    public interface IGenericDal<T> where T : class
    {
        // Modify
        void Insert(T t);
        string Add(T t);
        void Delete(T t);
        void Update(T t);
        // List
        List<T> GetList();
        List<T> GetAllWithFilter(Expression<Func<T, bool>> filter);
        // Find
        T FindById(int id);

        Task<T> CreateAsync(T t);
    }
}
