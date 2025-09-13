using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using VerticalSlicingSimpleApp.Common;
using VerticalSlicingSimpleApp.Data;
using VerticalSlicingSimpleApp.Featuers.Author.Dtos;
using VerticalSlicingSimpleApp.Models;

namespace VerticalSlicingSimpleApp.Featuers.Author.GetAllAuthors.Queries
{
    public record GetAllAuthorQuery
    (
        int PageNumber,
        int PageSize,
        string? SearchTerm,
        bool? IsActive
    ):IRequest<RequestResult<GetAllAuthorResonseViewModel>>;
    public class GetAllAuthorRequestQueryHandler : RequestHandlerBase<GetAllAuthorQuery, RequestResult<GetAllAuthorResonseViewModel>>
    {
        private readonly DbContextAdd _dbContextAdd;
        readonly DbSet<AuthorModel> _dbSet;
        public GetAllAuthorRequestQueryHandler(RequestHandlerBaseParameters parameters,
            DbContextAdd dbContextAdd) : base(parameters)
        {
            this._dbContextAdd = dbContextAdd;
            this._dbSet = _dbContextAdd.Set<AuthorModel>();
        }

        public async override Task<RequestResult<GetAllAuthorResonseViewModel>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
        {
            var query = _dbSet;
            var totalCount = await query.CountAsync(cancellationToken);
            var authors = await query
           .OrderBy(a => a.Name)
           .Skip((request.PageNumber - 1) * request.PageSize)
           .Take(request.PageSize)
           .Select(a => new AuthorDto
           {  
               Id=a.Id,
               Name=a.Name,
           })
           .ToListAsync(cancellationToken);

            var totalPages = (int)Math.Ceiling((double)totalCount / request.PageSize);
            var response = new GetAllAuthorResonseViewModel
            {
                Authers = authors,
                TotalCount = totalCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalPages = totalPages,
                HasNextPage = request.PageNumber < totalPages,
                HasPreviousPage = request.PageNumber > 1
            };
            return RequestResult<GetAllAuthorResonseViewModel>.Success(
             response);
        }
    }
}
