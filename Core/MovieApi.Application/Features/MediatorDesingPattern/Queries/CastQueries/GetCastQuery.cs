using MediatR;
using MovieApi.Application.Features.MediatorDesingPattern.Result.CatsResult;
using MovieApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesingPattern.Queries.CastQueries
{
    public class GetCastQuery:IRequest<List<GetCastQueryResult>>
    {
        public int CastId { get; set; }
        public GetCastQuery(int id)
        {
            CastId = id;

        }
    }
}
