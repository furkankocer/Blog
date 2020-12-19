using System.Collections.Generic;
using Blog.Entities.Concrete;
using Blog.Shared.Entities.Abstract;
using Blog.Shared.Utilities.Results.ComplexTypes;

namespace Blog.Entities.Dtos
{
    public class ArticleListDto : DtoGetBase
    {
        public IList<Article> Articles { get; set; }
    }
}