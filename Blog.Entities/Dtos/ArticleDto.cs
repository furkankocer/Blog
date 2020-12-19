using Blog.Entities.Concrete;
using Blog.Shared.Entities.Abstract;
using Blog.Shared.Utilities.Results.ComplexTypes;

namespace Blog.Entities.Dtos
{
    public class ArticleDto : DtoGetBase
    {
        public Article Article { get; set; }
    }
}