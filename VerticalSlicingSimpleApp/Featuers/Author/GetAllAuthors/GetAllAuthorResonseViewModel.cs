using VerticalSlicingSimpleApp.Featuers.Author.Dtos;

namespace VerticalSlicingSimpleApp.Featuers.Author.GetAllAuthors
{
    public class GetAllAuthorResonseViewModel
    {
        public List<AuthorDto> Authers { get; set; } = new();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
    }
}
