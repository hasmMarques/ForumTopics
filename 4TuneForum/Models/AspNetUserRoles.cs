namespace _4TuneForum.Models
{
	public partial class AspNetUserRoles
	{
		#region Properties

		public string UserId { get; set; }
		public string RoleId { get; set; }

		public virtual AspNetRoles Role { get; set; }
		public virtual AspNetUsers User { get; set; }

		#endregion
	}
}