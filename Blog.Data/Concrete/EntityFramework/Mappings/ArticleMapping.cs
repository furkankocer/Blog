using System;
using Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(x => x.Id); // Primary Key 
            builder.Property(x => x.Id).ValueGeneratedOnAdd(); // Increase one by one 
            builder.Property(x => x.Title).HasMaxLength(100);
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Content).IsRequired();
            
            builder.Property((x => x.Date)).IsRequired();
            builder.Property(x => x.SeoAuthor).IsRequired();
            builder.Property(x => x.SeoAuthor).HasMaxLength(50);
            builder.Property(x => x.SeoDescription).HasMaxLength(150);
            builder.Property(x => x.SeoDescription).IsRequired();
            builder.Property(x => x.SeoTags).HasMaxLength(70);
            builder.Property(x => x.ViewsCount).IsRequired();
            builder.Property(x => x.CommentCount).IsRequired();
            builder.Property(x => x.Thumbnail).IsRequired();
            builder.Property(x => x.Thumbnail).HasMaxLength(250);
            builder.Property(x => x.CreatedByName).HasMaxLength(50);
            builder.Property(x => x.CreatedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).HasMaxLength(50);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.Note).HasMaxLength(500);

            builder.HasOne<Category>(x => x.Category)
                .WithMany(c=>c.Articles)
                .HasForeignKey(x=>x.CategoryId);           
            
            builder.HasOne<User>(x => x.User)
                .WithMany(u=>u.Articles)
                .HasForeignKey(x=>x.UserId);

            builder.ToTable("Articles");

            builder.HasData(new Article
            {
                Id = 1,
                CategoryId = 1,
                Title = "C# 9 YENİLİKLERİ",
                Content =
                    $"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                Thumbnail = "Default.jpg",
                SeoDescription = "C# 9 YENİLİKLERİ",
                SeoTags = "c#,9,.net core",
                SeoAuthor = "Furkan Koçer",
                Date = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "C# 9 YENİLİKLERİ",
                UserId = 1,
                ViewsCount = 12,
                CommentCount = 1

            }, new Article
            {
                Id = 2,
                CategoryId = 2,
                Title = "C++ 9 YENİLİKLERİ",
                Content =
                    $"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                Thumbnail = "Default.jpg",
                SeoDescription = "C++ 9 YENİLİKLERİ",
                SeoTags = "C++,9,.net core",
                SeoAuthor = "Furkan Koçer",
                Date = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "C++ 9 YENİLİKLERİ",
                UserId = 1,
                ViewsCount = 12,
                CommentCount = 1
            },
            new Article
            {
                Id = 3,
                CategoryId = 3,
                Title = "JAVA  YENİLİKLERİ",
                Content =
                    $"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                Thumbnail = "Default.jpg",
                SeoDescription = "JAVA 9 YENİLİKLERİ",
                SeoTags = "JAVA,",
                SeoAuthor = "Furkan Koçer",
                Date = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "JAVA  YENİLİKLERİ",
                UserId = 1,
                ViewsCount = 12,
                CommentCount = 1
            });
        }
    }
}