using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesingPattern.Result.CategoryResult;
using MovieApi.Application.Features.CQRSDesingPattern.Result.MovieResult;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesingPattern.Handlers.MovieHandlers
{
    public class GetCategoryQueryHandler
    {
        public readonly MovieContext _context;
        public GetCategoryQueryHandler(MovieContext context)
        {
            _context = context;

        }

        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var values = await _context.Catogoryies.ToListAsync();
            return values.Select(x => new GetCategoryQueryResult
            {
                CategoryId=x.CategoryId,
                CategoryName=x.CategoryName,

            }).ToList();

        }
    }
}
