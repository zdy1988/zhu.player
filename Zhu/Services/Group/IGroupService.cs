﻿using Infrastructure.SearchModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhu.Models;

namespace Zhu.Services
{
    public interface IGroupService : IBaseService<Group>
    {
        Task<Tuple<List<Media>, int>> GetMediasForPagingAsync(int pageIndex, int pageSize, string orderField, bool isAsc, QueryModel model);
    }
}