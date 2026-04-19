using MediatR;
using MovieApi.Application.Features.MediatorDesingPattern.Result.CatsResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesingPattern.Queries.CastQueries
{
    public class GetCastByIdQuery : IRequest<List<GetCastByIdQueryResult>>
    {
        public int CastId { get; set; }

        public GetCastByIdQuery(int id)
        {
            CastId = id;

        }
    }  
}


    


