using System;
using System.Threading.Tasks;
using ProgrammersBlog.Data.Abstract;


namespace Blog.Data.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IArticleRepository Articles { get; }
        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }
        IRoleRepository Roles { get; }
        IUserRepository Users { get; }

        Task<int> SaveAsync();
    }
} 