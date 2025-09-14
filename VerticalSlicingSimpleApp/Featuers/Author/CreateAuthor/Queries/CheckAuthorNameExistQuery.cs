using MediatR;
using MediatR.Wrappers;
using Microsoft.EntityFrameworkCore;
using VerticalSlicingSimpleApp.Common;
using VerticalSlicingSimpleApp.Data;
using VerticalSlicingSimpleApp.Models;

namespace VerticalSlicingSimpleApp.Featuers.Author.CreateAuthor.Queries
{
    public record CheckAuthorNameExistQuery(string Name):IRequest<bool>;

    public class CheckAuthorNameExistQueryHandler : RequestHandlerBase<CheckAuthorNameExistQuery, bool>
    {
        private readonly DbContextApp _dbContext;
        private readonly DbSet<AuthorModel> dbset;

        public CheckAuthorNameExistQueryHandler(RequestHandlerBaseParameters parameters,DbContextApp dbContext) : base(parameters)
        {
            this._dbContext = dbContext;
            dbset=_dbContext.Set<AuthorModel>();
        }

        public async override Task<bool> Handle(CheckAuthorNameExistQuery request, CancellationToken cancellationToken)
        {
            var exist= await dbset.Where(a=> a.Name.ToLower()==request.Name.ToLower()).FirstOrDefaultAsync();
            return exist != null;
        }
    }
}
