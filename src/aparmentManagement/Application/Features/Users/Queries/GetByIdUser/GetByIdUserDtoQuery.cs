using Application.Features.Users.DTOs;
using AutoMapper;
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

            public Task<UserListDto> Handle(GetByIdUserDtoQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            #endregion
        }
    }
}
