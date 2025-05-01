using Microsoft.AspNetCore.Identity;

namespace IdentityChatMail.Models
{
    public class CustomIdentityValidator:IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description = "Sifre en az bir tane buyuk harf icermelidir!"
            };
        }
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresLower",
                Description = "Sifre en az bir tane kucuk harf icermelidir!"
            };
        }
        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresDigit",
                Description = "Sifre en az bir tane rakam icermelidir!"
            };
        }
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = "Sifre en az "+length+" karakter olmalidir!"
            };
        }
    }
}
