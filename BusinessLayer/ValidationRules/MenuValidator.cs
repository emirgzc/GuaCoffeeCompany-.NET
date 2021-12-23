using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class MenuValidator : AbstractValidator<Menu>
    {
        public MenuValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("En az 3 karakter girişi yapınız");
            RuleFor(x => x.Title).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapınız");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.Description).MinimumLength(2).WithMessage("En az 2 karakter girişi yapınız");
            RuleFor(x => x.Description).MaximumLength(1000).WithMessage("En fazla 1000 karakter girişi yapınız");
        }
    }
}
