using Application.Features.Users.DTOs;
using Application.Features.Users.Rules;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.DTOs;
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
        public UserRegistrationUpdateDto RegisterUpdateDto { get; set; }

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
                var userToUpdate = await _userRepository.GetAsync(u => u.Id == request.RegisterUpdateDto.Id);
                if (userToUpdate is null)
                    throw new BusinessException(Messages.User.UserNotFound);
                var mappedUser = _mapper.Map(request, userToUpdate);
                var uptadedUser = await _userRepository.UpdateAsync(mappedUser);
                var userToReturn = _mapper.Map<UpdateUserDto>(uptadedUser);
                return userToReturn;

            }
            #endregion
        }
    }
}
