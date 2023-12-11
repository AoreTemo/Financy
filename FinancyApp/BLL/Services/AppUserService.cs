using BLL.Interfaces;
using DAL.Interfaces;
using DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services;

public class AppUserService : GenericService<AppUser>, IAppUserService
{
    public AppUserService(IRepository<AppUser> repository) : base(repository)
    {
    }

}
