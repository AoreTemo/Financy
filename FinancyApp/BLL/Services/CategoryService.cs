using BLL.Interfaces;
using DAL.Interfaces;
using DL.Entities;

namespace BLL.Services;

public class CategoryService : GenericService<Category>, ICategoryService
{
    public CategoryService(IRepository<Category> repository) : base(repository)
    {
    }
}