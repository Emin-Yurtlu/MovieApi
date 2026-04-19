using MovieApi.Application.Features.CQRSDesingPattern.Commands.CategoryCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesingPattern.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        public readonly MovieContext _context;

        public UpdateCategoryCommandHandler(MovieContext context)
        {
            _context = context;

        }
        public async Task Handle(UpdateCategoryCommand command)
        {
            var value = await _context.Catogoryies.FindAsync(command.CategoryId);
            value.CategoryName= command.CategoryName;
            await _context.SaveChangesAsync();
            
        }

    }
}
