using Application.Features.Users.DTOs;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries.GetByIdUser
{
    public class GetByIdUserDtoQuery : IRequest<UserListDto>
    {
        public int Id { get; set; }
        
        public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserDtoQuery, UserListDto>
        {
            #region Variables
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            #endregion

            #region Constructor
            public GetByIdUserQueryHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }


            #endregion

            #region Method
            public async Task<UserListDto> Handle(GetByIdUserDtoQuery request, CancellationToken cancellationToken)
            {
                User user = await _userRepository.GetAsync(u => u.Id == request.Id);
                UserListDto userListDto = _mapper.Map<UserListDto>(user);
                return userListDto;
            }
            #endregion


        }
    }
}
