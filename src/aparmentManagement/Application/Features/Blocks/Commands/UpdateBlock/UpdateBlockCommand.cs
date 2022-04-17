using Application.Features.Blocks.DTOs;
using AutoMapper;
using Core.Utilities.Messages;
using Domain.Entities;
using MediatR;
using Persistence.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Features.Blocks.Commands.UpdateBlock
{
    public class UpdateBlockCommand : IRequest<UpdateBlockDto>
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public class UpdataColorCommandHandler : IRequestHandler<UpdateBlockCommand, UpdateBlockDto>
        {

            #region Variables
            private readonly IBlockRepository _blockRepository;
            private readonly IMapper _mapper;
            #endregion

            #region Constructor
            public UpdataColorCommandHandler(IBlockRepository blockRepository, IMapper mapper)
            {
                _blockRepository = blockRepository;
                _mapper = mapper;

            }
            #endregion

            #region Method
            public async Task<UpdateBlockDto> Handle(UpdateBlockCommand request, CancellationToken cancellationToken)
            {
                var check = await _blockRepository.GetAsync(b => b.Id == request.Id);
                if (check == null)
                    throw new Exception(Messages.Block.BlockNotFound);
                
                Block mappdedBlock = _mapper.Map<Block>(request);
                Block updatedBlock = await _blockRepository.UpdateAsync(mappdedBlock);
                UpdateBlockDto updateBlockDto = _mapper.Map<UpdateBlockDto>(updatedBlock);
                return updateBlockDto;

            }
            #endregion



        }
    }
}
