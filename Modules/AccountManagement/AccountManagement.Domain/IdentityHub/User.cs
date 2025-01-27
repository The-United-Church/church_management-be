using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.IdentityHub
{
    public class User
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DOB { get; set; }
        public DateTime BaptismDate { get; set; }
        public DateTime JoinedDate { get; set; }
        public MemberStatus MemberStatus { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string PhoneNumber { get; set; }
        public string SocialMediaHandle { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public List<User> FamilyMembers { get; set; }
        public string BaptismLocation { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool RequestPasswordReset { get; set; }
        public DateTime LastLoggedIn { get; set; }
        public IEnumerable<RefreshToken> RefreshTokens => _refreshToken;
        public ProfilePictureMeta ProfilePictureMeta { get; set; }
        public AccountType AccountType { get; set; }

        private List<RefreshToken> _refreshToken = new List<RefreshToken>();

    }
}
