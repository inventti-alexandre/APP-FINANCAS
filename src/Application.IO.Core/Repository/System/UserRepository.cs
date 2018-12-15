using Application.IO.Core.Context;
using Application.IO.Core.Identity.Models;
using Application.IO.Core.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IO.Core.Repository.System
{
    public class UserRepository : Repository<ApplicationUser>
    {
        public UserRepository(ApplicationDbContext  context) : base(context)
        {

        }
    }
}
