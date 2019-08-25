using System;
using Bogus;
using Academie.PawnShop.Domain.Entities;

namespace Academie.PawnShop.Domain.Fakers
{
    public sealed class UserFaker : Faker<User>
    {
        public static UserFaker DefaultInstance = new UserFaker();

        public UserFaker()
        {
            RuleFor(u => u.Id, () => Guid.NewGuid().ToString());
            RuleFor(u => u.Email, f => f.Internet.Email());
            RuleFor(u => u.UserName, (f, u) => u.Email);
            RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber());
            RuleFor(u => u.EmailConfirmed, true);
            RuleFor(u => u.PhoneNumberConfirmed, true);
            RuleFor(u => u.TwoFactorEnabled, false);
            RuleFor(u => u.LockoutEnabled, false);
            RuleFor(u => u.AccessFailedCount, 0);
        }
    }
}