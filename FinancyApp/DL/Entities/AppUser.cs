using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Entities;

public class AppUser: IdentityUser
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public int Balance { get; set; }
}
