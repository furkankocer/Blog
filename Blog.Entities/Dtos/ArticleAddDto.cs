using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Blog.Entities.Concrete;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Blog.Entities.Dtos
{
    public class ArticleAddDto
    {
        [DisplayName("Başlık")]
        public string Title { get; set; }
        [DisplayName("İçerik")]
        public string Content { get; set; }
        [DisplayName("Thumbnail")]
        public string Thumbnail { get; set; }
        [DisplayName("Tarih")]
        public DateTime DateTime { get; set; }
        [DisplayName("Seo Yazar")]
        public string SeoAuthor { get; set; }
        [DisplayName("Seo Açıklama")]
        public string SeoDescription { get; set; }
        [DisplayName("Seo Tags")]
        public string SeoTags { get; set; }
        [DisplayName("Kategori")]
        public int CategoryId { get; set; }
        public Category Category { get; set; } // Navigation Prop.
        
        [DisplayName("Aktif mi?")]
        public bool IsActive { get; set; }

        public class ArticleAddDtoDtoValidator : AbstractValidator<ArticleAddDto>
        {
            public ArticleAddDtoDtoValidator()
            {
                RuleFor(x => x.Title).NotNull().MaximumLength(100).WithMessage("100 karekterden büyük olamaz");
                RuleFor(x => x.Title).NotNull().MinimumLength(1).WithMessage("1 karekterden az olamaz");
                RuleFor(x => x.Content).NotNull().MinimumLength(20);
                RuleFor(x => x.Thumbnail).NotNull().MinimumLength(5).MaximumLength(250);
                RuleFor(x => x.SeoAuthor).NotNull().MinimumLength(1).MaximumLength(150);
                RuleFor(x => x.SeoDescription).NotNull().MinimumLength(1).MaximumLength(150);
                RuleFor(x => x.CategoryId).NotNull();
                RuleFor(x => x.IsActive).NotNull();
            }
        }
    }
}