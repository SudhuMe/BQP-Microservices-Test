using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Abstraction;

namespace AuthenticationService.Exceptions; 

public class RegisterException : BQValidationException
{
    public RegisterException(IEnumerable<IdentityError> errors) : base("Unable to register account.", 102)
    {
        BQValidationMessages = errors.Select(x => x.Description).ToList();
    }
}
