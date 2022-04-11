using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Hashing;
using Core.Utilities.Messages;
using Domain.Entities;
using Persistence.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        #region Variable
        private readonly IUserRepository _userRepository;
        #endregion

        #region Constructor
        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion

        #region Method
        public async Task UserIdShouldExistWhenSelected(int id) //BusinessRules?
        {
            User? result = await _userRepository.GetAsync(u => u.Id == id);
            if(result is null)
                throw new BusinessException(Messages.User.UserNotFound);
        }
        public Task UserPasswordShouldBeMatch(User user, string password)
        {
            if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new BusinessException(Messages.User.PasswordNotMatch);

            return Task.CompletedTask;
        }

        public Task UserShouldBeExist(User? user)
        {
            if (user is null) throw new BusinessException("User not exists.");
            return Task.CompletedTask;
        }




        #endregion
    }
}
