using Bogus.DataSets;
using Microsoft.AspNetCore.Identity;

namespace Academie.PawnShop.Domain.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }

        public User()
        {
            Address = new Address();
        }
    }
}