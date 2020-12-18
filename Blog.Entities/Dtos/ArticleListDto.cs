using System.Collections.Generic;
using Blog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Entities.Concrete;

namespace Blog.Entities.Dtos
{
    public class ArticleListDto
    {
        public IList<Article> Articles { get; set; }
    }
}