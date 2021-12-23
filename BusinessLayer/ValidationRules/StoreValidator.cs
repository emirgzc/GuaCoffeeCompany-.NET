using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class StoreValidator : AbstractValidator<Store>
    {
        public StoreValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.Title).MinimumLength(2).WithMessage("En az 2 karakter girişi yapınız");
            RuleFor(x => x.Title).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapınız");

            RuleFor(x => x.Color).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.Color).MinimumLength(2).WithMessage("En az 2 karakter girişi yapınız");
            RuleFor(x => x.Color).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapınız");
        }
    }
}
