using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Blog.Entities.Dtos
{
    public class CategoryAddDto
    {
        [DisplayName("Kategori Adı")]
        public string Name { get; set; }
        [DisplayName("Kategori Açıklaması")]
        public string Description { get; set; }
        [DisplayName("Kategori Özel Not Alanı")]
        public string Note { get; set; }
        [DisplayName("Aktif mi?")]
        public bool IsActive { get; set; }
        
        public class CategoryAddDtoValidator : AbstractValidator<CategoryAddDto>
        {
            public CategoryAddDtoValidator()
            {
                RuleFor(x => x.Name).MinimumLength(3).MaximumLength(70).NotEmpty().WithMessage("3 En fazla 70 karakter olmalıdır");
                RuleFor(x => x.Description).MaximumLength(3).MaximumLength(500).WithMessage("En az 3 En fazla 500 karakter olmalıdır");
                RuleFor(x => x.Note).MaximumLength(3).MaximumLength(500).WithMessage("En az 3 En fazla 500 karakter olmalıdır");
                RuleFor(x => x.IsActive).NotEmpty().WithMessage("Boş Geçilemez");
            }
        }
    }
}