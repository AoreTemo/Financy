using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Entities;

public class AppUser: IdentityUser
{
    public int Balance { get; set; }
    public string ConfirmPassword { get; set; }
    
    public List<Category> Categories { get; set; }
    public List<Cost> Costs { get; set; }
}
