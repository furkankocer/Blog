using Blog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Entities.Concrete;

namespace Blog.Entities.Dtos
{
    public class ArticleDto
    {
        public Article Article { get; set; }
        public ResultStatus ResultStatus { get; set; }
        
    }
}