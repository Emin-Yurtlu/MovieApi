using MovieApi.Application.Features.CQRSDesingPattern.Queries.CategoryQueries;
using MovieApi.Application.Features.CQRSDesingPattern.Queries.MovieQueries;
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
    public  class GetMovieByIdQueryHandler
    {
        public readonly MovieContext _context;

        public GetMovieByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<GetMovieByIdQueryResult> Handle(GetMovieByIdQuery query)
        {
            var values = await _context.Movies.FindAsync(query.MovieId);
            return new GetMovieByIdQueryResult
            {
                MovieId = values.MovieId,
               CoverImageUrl= values.CoverImageUrl,
               Description= values.Description,
               CreatedYears= values.CreatedYears,
                Duration= values.Duration,
                Rating= values.Rating,
                ReleaseDate= values.ReleaseDate,
                Status= values.Status,
                Title= values.Title,

            };
        }

     
    }
}
