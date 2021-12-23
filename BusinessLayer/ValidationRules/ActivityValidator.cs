using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class ActivityValidator : AbstractValidator<Activity>
	{
		public ActivityValidator()
		{
			RuleFor(x => x.Title).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
			RuleFor(x => x.Title).MinimumLength(2).WithMessage("En az 2 karakter girişi yapınız");
			RuleFor(x => x.Title).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapınız");

			RuleFor(x => x.Admin).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
			RuleFor(x => x.Admin).MinimumLength(2).WithMessage("En az 2 karakter girişi yapınız");
			RuleFor(x => x.Admin).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapınız");
		}
	}
}
