using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces;

public interface IGenericService<T>
{
    void Add(T item);
    void Update(T item);
    void Delete(int id);
    T? GetById(object id);
    List<T> GetByPredicate(Expression<Func<T, bool>> filter = null, Expression<Func<IQueryable<T>, IOrderedQueryable<T>>> orderBy = null);
}
