using System;
using Blog.Entities.Concrete;
using Blog.Shared.Data.Abstract;

namespace ProgrammersBlog.Data.Abstract
{
    public interface IArticleRepository : IEntitiyRepository <Article>
    {
    }
}
