using Application.Features.Users.Models;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries.GetUserList
{
    public class GetUserListDtoQuery : IRequest<UserListModel>
    {

        public PageRequest PageRequest { get; set; }

        public class GetUserListDtoQueryHandler : IRequestHandler<GetUserListDtoQuery,UserListModel>
        {
            #region Variables
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            #endregion

            #region Constructor
            public GetUserListDtoQueryHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            #endregion

            #region Method
            public async Task<UserListModel> Handle(GetUserListDtoQuery request, CancellationToken cancellationToken)
            {
                IPaginate<User> users = await _userRepository.GetListAsync(
                    include: c => c.Include(c => c.HomeOwnerType),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                UserListModel mappedUserListModel = _mapper.Map<UserListModel>(users);
                return mappedUserListModel;



            }
            #endregion
        }




    }
}
