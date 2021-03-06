using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.DTOs
{
    public class UserListDto
    {
        public int Id { get; set; }
        public string? HomeOwnerTypeDescription { get; set; }
        public long? IdentityNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PlateNumber { get; set; }
        public bool Status { get; set; }
    }
}
