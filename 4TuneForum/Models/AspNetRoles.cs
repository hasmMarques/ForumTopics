using System.Collections.Generic;

namespace _4TuneForum.Models
{
	public partial class AspNetRoles
	{
		#region Properties

		public string Id { get; set; }
		public string Name { get; set; }
		public string NormalizedName { get; set; }
		public string ConcurrencyStamp { get; set; }

		public virtual ICollection<AspNetRoleClaims> AspNetRoleClaims { get; set; }
		public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }

		#endregion

		#region Constructor

		public AspNetRoles()
		{
			AspNetRoleClaims = new HashSet<AspNetRoleClaims>();
			AspNetUserRoles = new HashSet<AspNetUserRoles>();
		}

		#endregion
	}
}