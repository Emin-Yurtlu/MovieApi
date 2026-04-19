using MediatR;
using MovieApi.Application.Features.MediatorDesingPattern.Commands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesingPattern.Handlers.CastHandlers
{
    public class RemoveCastCommandHandler : IRequestHandler<RemoveCastCommand>
    {
        private readonly MovieContext _context;

        public RemoveCastCommandHandler(MovieContext context)
        {
            _context = context;

        }

        public async Task Handle(RemoveCastCommand request, CancellationToken cancellationToken)
        {
            var values = _context.Casts.FindAsync(request.CastId);
            _context.Remove(values);
            await _context.SaveChangesAsync();
        }
    }
}
