using MovieApi.Application.Features.CQRSDesingPattern.Commands.CategoryCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesingPattern.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler
    {
        public readonly MovieContext _context;

        public RemoveCategoryCommandHandler(MovieContext context)
        {
            _context = context;
        }

    

    public async Task Handle(RemoveCategoryCommand command)
        {
            var value = _context.Catogoryies.Find(command.CategoryId);


            _context.Catogoryies.Remove(value);
            await _context.SaveChangesAsync();
        }
        
    }
}
