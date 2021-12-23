using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class SettingValidator : AbstractValidator<Setting>
	{
		public SettingValidator()
		{
			RuleFor(x => x.Address).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
			RuleFor(x => x.Address).MinimumLength(2).WithMessage("En az 2 karakter girişi yapınız");
			RuleFor(x => x.Address).MaximumLength(40).WithMessage("En fazla 40 karakter girişi yapınız");

			RuleFor(x => x.City).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
			RuleFor(x => x.City).MinimumLength(2).WithMessage("En az 2 karakter girişi yapınız");
			RuleFor(x => x.City).MaximumLength(50).WithMessage("En fazla 20 karakter girişi yapınız");

			RuleFor(x => x.Country).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
			RuleFor(x => x.Country).MinimumLength(2).WithMessage("En az 2 karakter girişi yapınız");
			RuleFor(x => x.Country).MaximumLength(20).WithMessage("En fazla 20 karakter girişi yapınız");

			RuleFor(x => x.Phone).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
			RuleFor(x => x.Phone).MinimumLength(2).WithMessage("En az 2 karakter girişi yapınız");
			RuleFor(x => x.Phone).MaximumLength(20).WithMessage("En fazla 20 karakter girişi yapınız");

			RuleFor(x => x.Email).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
			RuleFor(x => x.Email).MinimumLength(5).WithMessage("En az 5 karakter girişi yapınız");
			RuleFor(x => x.Email).MaximumLength(20).WithMessage("En fazla 20 karakter girişi yapınız");

			RuleFor(x => x.Facebook).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
			RuleFor(x => x.Facebook).MinimumLength(5).WithMessage("En az 5 karakter girişi yapınız");
			RuleFor(x => x.Facebook).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapınız");

			RuleFor(x => x.Youtube).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
			RuleFor(x => x.Youtube).MinimumLength(5).WithMessage("En az 5 karakter girişi yapınız");
			RuleFor(x => x.Youtube).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapınız");

			RuleFor(x => x.Instagram).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
			RuleFor(x => x.Instagram).MinimumLength(5).WithMessage("En az 5 karakter girişi yapınız");
			RuleFor(x => x.Instagram).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapınız");

			RuleFor(x => x.Map).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
			RuleFor(x => x.Map).MinimumLength(15).WithMessage("En az 15 karakter girişi yapınız");
			RuleFor(x => x.Map).MaximumLength(1500).WithMessage("En fazla 1500 karakter girişi yapınız");
		}
	}
}
