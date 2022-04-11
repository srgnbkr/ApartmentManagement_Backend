using Application.Features.Users.DTOs;
using Application.Features.Users.Rules;
using Application.Services.AuthService;
using AutoMapper;
using Core.Security.Hashing;
using Domain.Entities;
using MediatR;
using Persistence.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.UpdateUserFromAuth
{
    public class UpdateUserFromAuthCommand : IRequest<UpdatedUserFromAuthDto>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string? NewPassword { get; set; }

        public class UpdatedUserFromAuthCommandHandler : IRequestHandler<UpdateUserFromAuthCommand, UpdatedUserFromAuthDto>
        {
            #region Variables
            private readonly IUserRepository _userReposityory;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;
            private readonly IAuthService _authService;
            #endregion

            #region Constructor
            public UpdatedUserFromAuthCommandHandler(IUserRepository userRepository,
                IMapper mapper,UserBusinessRules userBusinessRules, IAuthService authService)
            {
                _userReposityory = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
                _authService = authService;
            }
            #endregion

            #region Method
            public async Task<UpdatedUserFromAuthDto> Handle(UpdateUserFromAuthCommand request, CancellationToken cancellationToken)
            {
                User? user = await _userReposityory.GetAsync(u => u.Id == request.Id);
                await _userBusinessRules.UserShouldBeExist(user);
                await _userBusinessRules.UserPasswordShouldBeMatch(user,request.Password);

                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                
                if(request.NewPassword is null && !string.IsNullOrWhiteSpace(request.NewPassword))
                {
                    byte[] passwordHash, passwordSalt;
                    HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                }

                User updatedUser = await _userReposityory.UpdateAsync(user);
                UpdatedUserFromAuthDto updatedUserFromAuthDto = _mapper.Map<UpdatedUserFromAuthDto>(updatedUser);
                updatedUserFromAuthDto.AccessToken = await _authService.CreateAccessToken(user);
                return updatedUserFromAuthDto;

            }
            #endregion
        }
    }
}
