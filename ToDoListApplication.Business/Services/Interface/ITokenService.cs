using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApplication.Business.Services.Interface
{
    public interface ITokenService
    {
        string CreateToken(IdentityUser user);
    }
}
