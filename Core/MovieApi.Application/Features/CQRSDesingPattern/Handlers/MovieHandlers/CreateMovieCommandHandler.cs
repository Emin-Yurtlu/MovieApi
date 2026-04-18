using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApi.Application.Features.CQRSDesingPattern.Commands.MovieCommands;


namespace MovieApi.Application.Features.CQRSDesingPattern.Handlers.MovieHandlers
{
    public class CreateMovieCommandHandler
    {
        private readonly MovieContext _context;
        public CreateMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async void Handle(CreateMovieCommand command)
        {
            _context.Movies.Add(new Movie
            {
                CoverImageUrl = command.CoverImageUrl,
                Description = command.Description,
                CreatedYears= command.CreatedYears,
                Duration = command.Duration,
                Title = command.Title,
                Status = command.Status,
                Rating = command.Rating,
                ReleaseDate = command.ReleaseDate
            });
            await _context.SaveChangesAsync();
        }
    }
}
