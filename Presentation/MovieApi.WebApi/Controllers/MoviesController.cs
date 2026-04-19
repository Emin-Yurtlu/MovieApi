using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesingPattern.Commands.MovieCommands;
using MovieApi.Application.Features.CQRSDesingPattern.Handlers.MovieHandlers;
using MovieApi.Application.Features.CQRSDesingPattern.Queries.MovieQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        public readonly CreateMovieCommandHandler _createMovieCommandHandler;
        public readonly GetMovieQueryHandler _getMovieQueryHandler;
        public readonly GetMovieByIdQueryHandler _getMovieByIdQueryHandler;
        public readonly RemoveMovieCommandHandler _removeMovieCommandHandler;
        public readonly UpdateMovieCommandHandler _updateMovieCommandHandler;
        public MoviesController(

         CreateMovieCommandHandler createMovieCommandHandler,
         GetMovieQueryHandler getMovieQueryHandler,
         GetMovieByIdQueryHandler getMovieByIdQueryHandler,
         RemoveMovieCommandHandler removeMovieCommandHandler,
         UpdateMovieCommandHandler updateMovieCommandHandler)
        {

            _createMovieCommandHandler = createMovieCommandHandler;
            _getMovieQueryHandler = getMovieQueryHandler;
            _getMovieByIdQueryHandler = getMovieByIdQueryHandler;
            _removeMovieCommandHandler = removeMovieCommandHandler;
            _updateMovieCommandHandler = updateMovieCommandHandler;

        }


        [HttpGet]
        public async Task<IActionResult> MovieList()
        {
            var values = await _getMovieQueryHandler.Handle();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(CreateMovieCommand command)
        {
            await _createMovieCommandHandler.Handle(command);
            return Ok("Film Ekleme İşlemi Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _removeMovieCommandHandler.Handle(new RemoveMovieCommand(id));
            return Ok("Film Silme İşlemi Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovie(UpdateMovieCommand command)
        {
            await _updateMovieCommandHandler.Handle(command);
            return Ok("Film Güncelleme İşlemi Başarılı");
        }
        [HttpGet("GetMovie")]
        public async Task<IActionResult> GetMovie(int id)
        {

            var value = await _getMovieByIdQueryHandler.Handle(new GetMovieByIdQuery(id));

            return Ok(value);


        }
    }
}

