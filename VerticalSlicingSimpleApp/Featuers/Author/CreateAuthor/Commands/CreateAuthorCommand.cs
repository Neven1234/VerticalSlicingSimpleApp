using MediatR;
using Microsoft.EntityFrameworkCore;
using VerticalSlicingSimpleApp.Common;
using VerticalSlicingSimpleApp.Data;
using VerticalSlicingSimpleApp.Featuers.Author.Dtos;
using VerticalSlicingSimpleApp.Models;

namespace VerticalSlicingSimpleApp.Featuers.Author.CreateAuthor.Commands
{
    public record CreateAuthorCommand(string Name):IRequest<AuthorDto>;
    public class CreatAuthorCommandHandler : RequestHandlerBase<CreateAuthorCommand, AuthorDto>
    {
        private readonly DbContextApp _dbContext;
        private readonly DbSet<AuthorModel> dbset;

        public CreatAuthorCommandHandler(RequestHandlerBaseParameters parameters,DbContextApp dbContext) : base(parameters)
        {
            this._dbContext = dbContext;
            dbset= _dbContext.Set<AuthorModel>();
        }

        public override async Task<AuthorDto> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            AuthorModel newAuthor = new AuthorModel
            {
                Name= request.Name,

            };
            var result=await dbset.AddAsync(newAuthor);
            await _dbContext.SaveChangesAsync();
            return new AuthorDto { Name = request.Name, Id=newAuthor.Id};
        }
    }

}
