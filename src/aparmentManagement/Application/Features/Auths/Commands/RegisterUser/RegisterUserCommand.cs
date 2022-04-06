using Application.Features.Auths.DTOs;
using AutoMapper;
using Core.Security.DTOs;
using Core.Security.Hashing;
using Domain.Entities;
using MediatR;
using Persistence.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<RegisterUserDto>
    {
        public UserForRegisterDto RegisterDto { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserDto>
        {

            #region Variables
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            #endregion

            #region Constructor
            public CreateUserCommandHandler(IUserRepository userRepository,IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }
            #endregion
            
            #region Methods
            /// <summary>
            /// 
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public async Task<RegisterUserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                var userToRegister = _mapper.Map<User>(request.RegisterDto);

                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.RegisterDto.Password, out passwordHash, out passwordSalt);
                userToRegister.PasswordSalt = passwordSalt;
                userToRegister.PasswordHash = passwordHash;
                userToRegister.Status = true;

                var createdUser = await _userRepository.AddAsync(userToRegister);
                var userToReturn = _mapper.Map<RegisterUserDto>(createdUser);
                return userToReturn;
            }
            #endregion





        }
    }
}
