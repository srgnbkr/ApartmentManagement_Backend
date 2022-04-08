using Application.Features.Users.DTOs;
using Application.Features.Users.Rules;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.DTOs;
using Core.Security.Hashing;
using Core.Utilities.Messages;
using Domain.Entities;
using MediatR;
using Persistence.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<UpdateUserDto>
    {
        public int Id { get; set; }
        public int? HomeOwnerTypeId { get; set; }
        public long? IdentityNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }


        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserDto>
        {
            #region Variables
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            
            #endregion

            #region Constructor
            public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                
            }



            #endregion

            #region Method
            public async  Task<UpdateUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {

                User mappedUser = _mapper.Map<User>(request);
                HashingHelper.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
                mappedUser.PasswordHash = passwordHash;
                mappedUser.PasswordSalt = passwordSalt;

                User updateUser = await _userRepository.UpdateAsync(mappedUser);
                UpdateUserDto updateUserDto = _mapper.Map<UpdateUserDto>(updateUser);
                return updateUserDto;

            }
            #endregion
        }
    }
}
