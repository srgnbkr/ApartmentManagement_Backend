using Application.Features.Blocks.DTOs;
using Application.Features.Blocks.Rules;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Blocks.Commands.CreateBlock
{
    public class CreateBlockCommand : IRequest<CreateBlockDto>
    {
        public string Description { get; set; }

        public class CreateBlockCommandHandler : IRequestHandler<CreateBlockCommand, CreateBlockDto>
        {
            #region Variables
            private readonly IBlockRepository _blockRepository;
            private readonly IMapper _mapper;
            private readonly BlockBusinessRules _blockBusinessRules;
            #endregion

            #region Constructor
            public CreateBlockCommandHandler(IBlockRepository blockRepository, IMapper mapper,BlockBusinessRules blockBusinessRules)
            {
                _blockRepository = blockRepository;
                _mapper = mapper;
                _blockBusinessRules = blockBusinessRules;
            }

            #endregion

            #region Method
            public async Task<CreateBlockDto> Handle(CreateBlockCommand request, CancellationToken cancellationToken)
            {
                await _blockBusinessRules.BlockNameExists(request.Description);
                Block mappedBlock = _mapper.Map<Block>(request);
                Block createdBlock = await _blockRepository.AddAsync(mappedBlock);
                CreateBlockDto createBlockDto = _mapper.Map<CreateBlockDto>(createdBlock);
                return createBlockDto;
            }
            #endregion



        }
    }
}
