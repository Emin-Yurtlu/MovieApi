using MovieApi.Application.Features.CQRSDesingPattern.Commands.MovieCommands;
using MovieApi.Persistence.Context;
using System;

namespace MovieApi.Application.Features.CQRSDesingPattern.Handlers.MovieHandlers
{
    public class UpdateMovieCommandHandler
    {
        public readonly MovieContext _context;

        public UpdateMovieCommandHandler(MovieContext context)
        {
            _context = context;

        }
        public async Task Handle(UpdateMovieCommand command)
        {
            var value = await _context.Movies.FindAsync(command.MovieId);
            
                value.Title = command.Title;
                value.Description = command.Description;
                value.CoverImageUrl = command.CoverImageUrl;
                value.CreatedYears = command.CreatedYears;
                value.Duration = command.Duration;
                value.Status = command.Status;
                value.Rating = command.Rating;
                value.ReleaseDate = command.ReleaseDate;
                await _context.SaveChangesAsync();
            
        }

    }

}