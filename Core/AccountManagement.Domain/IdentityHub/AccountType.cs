using System.ComponentModel;

namespace AccountManagement.Domain.IdentityHub
{
    public enum AccountType
    {
        [Description(Account.USER)] User,
        [Description(Account.ADMIN)] Admin,
    }

    public static class Account
    {
        public const string ADMIN = "Administrator";
        public const string USER = "User";
    }
}
