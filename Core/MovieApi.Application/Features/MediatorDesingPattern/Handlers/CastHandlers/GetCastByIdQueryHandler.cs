using MediatR;
using MovieApi.Application.Features.MediatorDesingPattern.Queries.CastQueries;
using MovieApi.Application.Features.MediatorDesingPattern.Result.CatsResult;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieApi.Application.Features.MediatorDesingPattern.Handlers.CastHandlers
{
    public class GetCastByIdQueryHandler : IRequestHandler<GetCastByIdQuery, GetCastByIdQueryResult>
    {
        private readonly MovieContext _context;

        public GetCastByIdQueryHandler(MovieContext context)
        {
            _context = context;
            
        }
        public async Task<GetCastByIdQueryResult> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Casts.FindAsync(request.CastId);
            return new GetCastByIdQueryResult
            {

                Biography = values.Biography,
                CastId = values.CastId,
                ImageUrl = values.ImageUrl,
                Name = values.Name,
                OverView = values.OverView,
                Surname = values.Surname,
                Title = values.Title,
            };
        }
    }
}
