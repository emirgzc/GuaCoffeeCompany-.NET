﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class AdminValidator : AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.Username).MinimumLength(3).WithMessage("En az 3 karakter girişi yapınız");
            RuleFor(x => x.Username).MaximumLength(50).WithMessage("En fazla 50 karakter girişi yapınız");

            RuleFor(x => x.Password).MinimumLength(3).WithMessage("En az 3 karakter girişi yapınız");
            RuleFor(x => x.Password).MaximumLength(50).WithMessage("En fazla 50 karakter girişi yapınız");
        }
    }
}
