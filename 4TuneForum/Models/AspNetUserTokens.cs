namespace _4TuneForum.Models
{
	public partial class AspNetUserTokens
	{
		#region Properties

		public string UserId { get; set; }
		public string LoginProvider { get; set; }
		public string Name { get; set; }
		public string Value { get; set; }

		public virtual AspNetUsers User { get; set; }

		#endregion
	}
}