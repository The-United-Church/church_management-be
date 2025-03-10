namespace AccountManagement.Domain.IdentityHub
{
    public class RefreshToken
    {
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
