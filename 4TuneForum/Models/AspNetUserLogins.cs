namespace _4TuneForum.Models
{
	public partial class AspNetUserLogins
	{
		#region Properties

		public string LoginProvider { get; set; }
		public string ProviderKey { get; set; }
		public string ProviderDisplayName { get; set; }
		public string UserId { get; set; }

		public virtual AspNetUsers User { get; set; }

		#endregion
	}
}