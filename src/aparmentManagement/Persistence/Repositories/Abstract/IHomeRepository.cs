﻿using Core.Persistence.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Abstract
{
    public interface IHomeRepository : IAsyncRepository<Home>
    {
    }
}
