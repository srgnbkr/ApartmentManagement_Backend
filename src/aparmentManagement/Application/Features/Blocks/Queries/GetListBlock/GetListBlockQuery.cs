using Application.Features.Blocks.Models;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Persistence.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Blocks.Queries.GetListBlock
{
    public class GetListBlockQuery : IRequest<BlockListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListBlockQueryHandler : IRequestHandler<GetListBlockQuery, BlockListModel>
        {
            #region Variables
            private readonly IBlockRepository _blockRepository;
            private readonly IMapper _mapper;
            #endregion

            #region Constructor
            public GetListBlockQueryHandler(IBlockRepository blockRepository, IMapper mapper)
            {
                _blockRepository = blockRepository;
                _mapper = mapper;
            }


            #endregion 

            #region Method
            /// <summary>
            /// 
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public async Task<BlockListModel> Handle(GetListBlockQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Block> blocks = await _blockRepository.GetListAsync(index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                BlockListModel mappedBlockListModel = _mapper.Map<BlockListModel>(blocks);
                return mappedBlockListModel;
            }
            #endregion

        }
    }
}




        
            


    

