using Application.Features.Blocks.DTOs;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Blocks.Models
{
    public class BlockListModel : BasePagebleModel
    {
        public IList<BlockListDto> Items { get; set; }
    }
}
