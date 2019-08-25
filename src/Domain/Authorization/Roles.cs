using System;
using System.Collections.Generic;
using Academie.PawnShop.Domain.Entities;

namespace Academie.PawnShop.Domain.Authorization
{
    public static class Roles
    {
        public static IEnumerable<Role> GetAllRoles()
        {
            var roles = typeof(Constants.Authorization.Roles).GetFields();

            foreach (var field in roles)
            {
                var roleName = field.GetValue(null) as string;
                yield return new Role
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = roleName
                };
            }
        }
    }
}