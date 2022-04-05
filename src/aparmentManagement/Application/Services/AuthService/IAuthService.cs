using Core.Security.JWT;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AuthService
{
    public interface IAuthService
    {
        Task<bool> UserExists(string email);
        Task<AccessToken> CreateAccessToken(User user);
    }
}
