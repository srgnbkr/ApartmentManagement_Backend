using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities.Messages;
using Domain.Entities;
using Persistence.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserService
{
    public class UserManager : IUserService
    {
        #region Variables
        private readonly IUserRepository userRepository;
        #endregion

        #region Constructor
        public UserManager(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }


        #endregion

        #region Methods
        
        public async Task<User> GetByMail(string email)
        {
            var result = await this.userRepository.GetAsync(u => u.Email == email);
            if (result is null)
            {
                throw new BusinessException(Messages.User.UserNotFound);
            }
            return result;
        }
            

        public  Task<List<OperationClaim>> GetClaims(User user)
        {
            var result = Task.Run(() =>
            {
                var claims = this.userRepository.GetClaims(user);

                if (claims is null)
                {
                    throw new BusinessException(Messages.User.UserNotFound);
                }

                return claims;
            });

            return result;

        }
        #endregion
    }
}
