using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //generic constraints:
    //class: referans tip
    //IEntity: IEntity olabilir veya IEntity implement eden bir nesne olabilir
    //new(): new'lenebilir olmalı
    public interface IEntityRepository<T> where T:class, IEntity, new() // Generic Respository Design Pattern
    {
        List<T> GetAll(Expression<Func<T, bool>> filter=null); // {{mükemmel bir yapı}}
        T GetById(Expression<Func<T, bool>> filter); // tek bir item döndürebilmek için
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
