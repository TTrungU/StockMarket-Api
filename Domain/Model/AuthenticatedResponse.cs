using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class AuthenticatedResponse
    {
        public int? Id { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Token { get; set; }

        public AuthenticatedResponse(User user,string token)
        {
            Id = user.Id;
            LastName = user.LastName;
            FirstName = user.FirstName;
            Email = user.Email;
            DateOfBirth = user.DateOfBirth;
            Token = token;
        }
    }
}
