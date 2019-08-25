using System;
using System.Collections.Generic;
using Academie.PawnShop.Domain.Entities;

namespace Academie.PawnShop.Domain.Authorization
{
    public static class SuperAdmins
    {
        public static IEnumerable<User> GetAllSuperAdmins()
        {
            var superAdmins = typeof(Constants.Authorization.SuperAdmins).GetFields();

            foreach (var field in superAdmins)
            {
                var superAdminEmail = field.GetValue(null) as string;
                yield return new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = superAdminEmail,
                    Email = superAdminEmail,
                    EmailConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false
                };
            }
        }
    }
}