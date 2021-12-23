using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class SliderValidator : AbstractValidator<Slider>
	{
		public SliderValidator()
		{
			RuleFor(x => x.Title).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
			RuleFor(x => x.Title).MinimumLength(2).WithMessage("En az 2 karakter girişi yapınız");
			RuleFor(x => x.Title).MaximumLength(150).WithMessage("En fazla 150 karakter girişi yapınız");

			RuleFor(x => x.Description).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
			RuleFor(x => x.Description).MinimumLength(5).WithMessage("En az 5 karakter girişi yapınız");
			RuleFor(x => x.Description).MaximumLength(500).WithMessage("En fazla 500 karakter girişi yapınız");
		}
	}
}
