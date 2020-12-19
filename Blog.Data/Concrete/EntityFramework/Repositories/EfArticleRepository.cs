using System;
using Blog.Entities.Concrete;
using Blog.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Data.Abstract;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Contexts
{
    public class EfArticleRepository : EfEntityRepositoryBase<Article>, IArticleRepository
    {
        public EfArticleRepository(DbContext context) : base(context)
        {
        }
    }
}
