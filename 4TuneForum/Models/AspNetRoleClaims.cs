namespace _4TuneForum.Models
{
	public partial class AspNetRoleClaims
	{
		#region Properties

		public int Id { get; set; }
		public string RoleId { get; set; }
		public string ClaimType { get; set; }
		public string ClaimValue { get; set; }

		public virtual AspNetRoles Role { get; set; }

		#endregion
	}
}