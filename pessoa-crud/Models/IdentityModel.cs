﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pessoa_crud.Models
{
    public class IdentityModels
    {
    }

    public class ApplicationUserRole : IdentityRole { }

    public class ApplicationUser : IdentityUser { }
}

