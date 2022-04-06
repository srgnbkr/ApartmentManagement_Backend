using Application.Features.Auths.DTOs;
using Application.Services.AuthService;
using AutoMapper;
using Core.Security.Hashing;
using Core.Utilities.Messages;
using MediatR;
using Persistence.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<LoginUserDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }


        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand,LoginUserDto>
        {
            #region Variables
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly IAuthService _authService;
            #endregion

            #region Constructor
            public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper, IAuthService authService)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _authService = authService;
            }
            #endregion
            
            #region Methods
            public async Task<LoginUserDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                var userCheck = await _userRepository.GetAsync(u => u.Email == request.Email);
                if (userCheck is null)
                    throw new Exception(Messages.User.UserNotFound);

                if (!HashingHelper.VerifyPasswordHash(request.Password, userCheck.PasswordHash, userCheck.PasswordSalt))
                    throw new Exception(Messages.User.PasswordError);

                var accessToken = await _authService.CreateAccessToken(userCheck);


                return new LoginUserDto
                {
                    AccessToken = accessToken
                    
                };
            }
            #endregion
            
            












        }
    }
    
    
}
