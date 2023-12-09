﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class AppDbContext: IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
    {

    }


}