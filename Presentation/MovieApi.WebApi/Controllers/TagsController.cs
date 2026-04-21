using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesingPattern.Commands.MovieCommands;
using MovieApi.Application.Features.CQRSDesingPattern.Handlers.MovieHandlers;
using MovieApi.Application.Features.MediatorDesingPattern.Commands.CastCommands;
using MovieApi.Application.Features.MediatorDesingPattern.Commands.TagCommands;
using MovieApi.Application.Features.MediatorDesingPattern.Queries.TagQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TagsController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpGet]
        public async Task< IActionResult> TagList()
        {
            var values = await _mediator.Send(new GetTagQuery());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag(CreateTagCommand command)
        {
             await _mediator.Send(command);
            return Ok("Ekleme İşlemi Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTag(int id)
        {
            await _mediator.Send(new RemoveTagCommand(id));
            return Ok("Silme İşlemi Başarılı");
        }

        [HttpGet("GetByIdTag")]
        public async Task< IActionResult> GetTagById(int id)
        {
            var values = await _mediator.Send(new GetTagByIdQuery(id));
            return Ok(values);
        }
        [HttpPut]
        public async Task < IActionResult> UpdateTag(UpdateTagCommand command)
        {
             await _mediator.Send(command);
            return Ok("Güncelleme İşlemi Başarılı");
        }

    }
}
