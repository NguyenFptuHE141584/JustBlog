using FA.JustBlog.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Infrastructures
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }

        ICommentRepository CommentRepository { get; }

        IPostRepository PostRepository { get; }

        ITagRepository TagRepository { get; }

        JustBlogContext JustBlogContext { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}