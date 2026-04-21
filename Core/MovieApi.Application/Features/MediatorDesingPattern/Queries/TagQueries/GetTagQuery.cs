using MediatR;
using MovieApi.Application.Features.MediatorDesingPattern.Results.TagResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesingPattern.Queries.TagQueries
{
    public class GetTagQuery:IRequest<List<GetTagQueryResult>>
    {
        public int TagId { get; set; }

    }
}
