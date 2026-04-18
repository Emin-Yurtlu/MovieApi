using MovieApi.Application.Features.CQRSDesingPattern.Queries.CategoryQueries;
using MovieApi.Application.Features.CQRSDesingPattern.Result.MovieResult;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesingPattern.Handlers.MovieHandlers
{
    public  class GetMovieQueryByIdHandler
    {
        public readonly MovieContext _context;

        public GetMovieQueryByIdHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<GetMovieByIdQueryResult> Handler(GetMovieByIdQueryResult query)
        {
            var values = await _context.Catogoryies.FindAsync(query.MovieId);
            return new GetMovieByIdQueryResult
            {
               CoverImageUrl= query.CoverImageUrl,
               Description= query.Description,
               CreatedYears= query.CreatedYears,
                Duration= query.Duration,
                Rating= query.Rating,
                ReleaseDate= query.ReleaseDate,
                Status= query.Status,
                Title= query.Title,

            };
        }
    }
}
