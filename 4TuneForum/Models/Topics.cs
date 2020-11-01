using System;
using System.ComponentModel.DataAnnotations;

namespace _4TuneForum.Models
{
	public partial class Topics
	{
		#region Properties

		public int Id { get; set; }

		[Required]
		[StringLength(20)]
		public string Title { get; set; }

		[Required]
		[StringLength(500)]
		public string Description { get; set; }

		[Required]
		public string Creator { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public DateTime CreationDate { get; set; }

		public virtual AspNetUsers CreatorNavigation { get; set; }

		#endregion
	}
}