using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MovieApi.Application.Features.CQRSDesingPattern.Commands.CategoryCommands;
using MovieApi.Application.Features.CQRSDesingPattern.Handlers.CategoryHandlers;
using MovieApi.Application.Features.CQRSDesingPattern.Handlers.MovieHandlers;
using MovieApi.Application.Features.CQRSDesingPattern.Queries.CategoryQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        public readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        public readonly GetCategoryByIdQueryHandler _getCategoryyByIdQuerHandler;
        public readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;
        public readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;

        public CategoriesController(
        CreateCategoryCommandHandler createCategoryCommandHandler,
        GetCategoryQueryHandler getCategoryQueryHandler,
        GetCategoryByIdQueryHandler getCategoryQueryByIdHandler,
        RemoveCategoryCommandHandler removeCategoryCommandHandler,
        UpdateCategoryCommandHandler updateCategoryCommandHandler
            )
        {
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _getCategoryyByIdQuerHandler = getCategoryQueryByIdHandler;
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;

        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _getCategoryQueryHandler.Handle();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await _createCategoryCommandHandler.Handle(command);
            return Ok("Kategori Ekleme İşlemi Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
            return Ok("Kategori Silme İşlemi Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await _updateCategoryCommandHandler.Handle(command);
            return Ok("Kategori Güncelleme İşlemi Başarılı");
        }

        [HttpGet("GetCategory")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var value = await _getCategoryyByIdQuerHandler.Handle(new GetCategoryByIdQuery(id));
            return Ok(value);


        }
    }
}
