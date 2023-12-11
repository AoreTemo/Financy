using BLL.Interfaces;
using DAL.Interfaces;
using DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services;

public class CostService : GenericService<Cost>, ICostService
{
    public CostService(IRepository<Cost> repository) : base(repository)
    {
    }
}
