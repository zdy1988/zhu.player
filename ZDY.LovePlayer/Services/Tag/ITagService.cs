﻿using Infrastructure.SearchModel.Model;
using ZDY.LovePlayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZDY.LovePlayer.Services
{
    public interface ITagService : IBaseService<Tag>
    {
        Task<Tuple<List<string>, int>> GetTagsForPagingAsync(int pageIndex, int pageSize, QueryModel model);
    }
}
