using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Common.Entities
{
    public class ApplicationUser: IdentityUser
    {
        public string FullName { get; set; } // Example custom property
        public string FavoriteDeck { get; set; } // Example custom property
    }
}
