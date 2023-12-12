using BLL.Interfaces;
using DAL.Interfaces;
using System.Linq.Expressions;

namespace BLL.Services;

public abstract class GenericService<T> : IGenericService<T> where T : class
{
    protected IRepository<T> _repository;

    protected GenericService(IRepository<T> repository)
    {
        _repository = repository;
    }

    public void Add(T item)
    {
        _repository.Add(item);
        _repository.SaveChanges();
    }

    public void Update(T item)
    {
        _repository.Update(item);
        _repository.SaveChanges();
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
        _repository.SaveChanges();
    }

    public T? GetById(object id)
    {
        var item = _repository.FindById(id);

        return item;
    }

    public List<T> GetByPredicate(
        Expression<Func<T, bool>> filter = null, 
        Expression<Func<IQueryable<T>, IOrderedQueryable<T>>> orderBy = null)
    {
        var query = _repository.GetAllAsList().AsQueryable();
        if (filter != null)
        {
            query = query.Where(filter);
        }
        if (orderBy != null)
        {
            query = orderBy.Compile()(query);
        }
        return query.ToList();
    }
}
