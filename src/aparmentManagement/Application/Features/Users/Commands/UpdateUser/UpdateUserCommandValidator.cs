using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().MinimumLength(3);
            RuleFor(u => u.LastName).NotEmpty().MinimumLength(3);
            RuleFor(u => u.Email).NotEmpty().EmailAddress();
            RuleFor(u => u.Password).NotEmpty().Length(6, 22);
            RuleFor(u => u.IdentityNumber).NotEmpty();
            RuleFor(u => u.PhoneNumber).NotEmpty().Length(11);
            RuleFor(u => u.HomeOwnerTypeId).NotEmpty();
        }
    }
}
