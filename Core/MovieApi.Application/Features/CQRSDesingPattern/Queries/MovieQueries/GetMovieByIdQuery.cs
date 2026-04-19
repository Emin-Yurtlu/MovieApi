using Microsoft.EntityFrameworkCore.ChangeTracking;
using MovieApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesingPattern.Queries.MovieQueries
{
    public class GetMovieByIdQuery
    {
        public GetMovieByIdQuery(int id)
        {
            MovieId = id;

        }
        public int MovieId { get; set; }

    }
}
