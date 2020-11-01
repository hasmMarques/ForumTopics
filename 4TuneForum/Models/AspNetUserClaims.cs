namespace _4TuneForum.Models
{
	public partial class AspNetUserClaims
	{
		#region Properties

		public int Id { get; set; }
		public string UserId { get; set; }
		public string ClaimType { get; set; }
		public string ClaimValue { get; set; }

		public virtual AspNetUsers User { get; set; }

		#endregion
	}
}