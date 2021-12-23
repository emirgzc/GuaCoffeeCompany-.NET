using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class VideoValidator : AbstractValidator<Video>
    {
        public VideoValidator()
        {
            RuleFor(x => x.VideoURL).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.VideoURL).MinimumLength(2).WithMessage("En az 2 karakter girişi yapınız");
            RuleFor(x => x.VideoURL).MaximumLength(250).WithMessage("En fazla 250 karakter girişi yapınız");
        }
    }
}
