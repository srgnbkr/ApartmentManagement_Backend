using Application.Services.UserService;
using Core.Security.JWT;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AuthService
{
    public class AuthManager : IAuthService
    {
        #region Variables
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        #endregion

        #region Constructor
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }


        #endregion


        #region Methods
        public async Task<AccessToken> CreateAccessToken(User user)
        {
            var claims = await _userService.GetClaims(user);
            var accessToken = await _tokenHelper.CreateToken(user, claims);
            return accessToken;
        }

        public async Task<bool> UserExists(string email)
        {
            return await _userService.GetByMail(email) != null;
        }
        #endregion


    }



}


