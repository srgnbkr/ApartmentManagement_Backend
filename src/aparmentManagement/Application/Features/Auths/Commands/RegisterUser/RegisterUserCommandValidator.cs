using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.RegisterUser
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(u => u.RegisterDto.FirstName).NotEmpty().MinimumLength(3);
            RuleFor(u => u.RegisterDto.LastName).NotEmpty().MinimumLength(3);
            RuleFor(u => u.RegisterDto.Email).NotEmpty().EmailAddress();
            RuleFor(u => u.RegisterDto.Password).NotEmpty().Length(6,22);
            RuleFor(u => u.RegisterDto.IdentityNumber).NotEmpty();
            RuleFor(u => u.RegisterDto.PhoneNumber).NotEmpty().Length(11);
            
        }
    }
}
