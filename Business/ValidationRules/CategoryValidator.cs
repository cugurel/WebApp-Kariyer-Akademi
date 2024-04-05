using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori Adı Boş Olamaz");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Kategori adı en az 3 karakterden oluşmalıdır.");
        }
    }
}
