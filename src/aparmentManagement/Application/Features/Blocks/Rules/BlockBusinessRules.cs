using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Utilities.Messages;
using Domain.Entities;
using Persistence.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Blocks.Rules
{
    public class BlockBusinessRules
    {

        #region Variables
        private readonly IBlockRepository _blockRepository;
        #endregion

        #region Constructor
        public BlockBusinessRules(IBlockRepository blockRepository)
        {
            _blockRepository = blockRepository;
        }
        #endregion

        #region Methods
        public async Task BlockNameExists(string blockName)
        {
            IPaginate<Block> result = await _blockRepository.GetListAsync(u => u.Description == blockName);
            if(result.Items.Any())
                throw new BusinessException(Messages.Block.BlockNameExists);


        }
        #endregion


    }
}
