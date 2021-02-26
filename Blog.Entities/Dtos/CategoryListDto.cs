using System.Collections.Generic;
using Blog.Entities.Concrete;
using Blog.Shared.Entities.Abstract;

namespace Blog.Entities.Dtos
{
    public class CategoryListDto:DtoGetBase
    {
        public IList<Category> Categories { get; set; }
    }
}
