using Microsoft.EntityFrameworkCore;

namespace _4TuneForum.Models
{
	public partial class aspnet_4TuneForumContext : DbContext
	{
		#region Properties

		public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
		public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
		public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
		public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
		public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
		public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
		public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
		public virtual DbSet<Topics> Topics { get; set; }

		#endregion

		#region Constructor

		public aspnet_4TuneForumContext()
		{
		}

		public aspnet_4TuneForumContext(DbContextOptions<aspnet_4TuneForumContext> options)
			: base(options)
		{
		}

		#endregion

		#region Protected Methods

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-RAISED2\\SQLEXPRESS;Database=aspnet-_4TuneForum;Integrated Security=True");
//            }
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AspNetRoleClaims>(entity =>
			{
				entity.HasIndex(e => e.RoleId);

				entity.Property(e => e.RoleId).IsRequired();

				entity.HasOne(d => d.Role)
					.WithMany(p => p.AspNetRoleClaims)
					.HasForeignKey(d => d.RoleId);
			});

			modelBuilder.Entity<AspNetRoles>(entity =>
			{
				entity.HasIndex(e => e.NormalizedName)
					.HasName("RoleNameIndex")
					.IsUnique()
					.HasFilter("([NormalizedName] IS NOT NULL)");

				entity.Property(e => e.Name).HasMaxLength(256);

				entity.Property(e => e.NormalizedName).HasMaxLength(256);
			});

			modelBuilder.Entity<AspNetUserClaims>(entity =>
			{
				entity.HasIndex(e => e.UserId);

				entity.Property(e => e.UserId).IsRequired();

				entity.HasOne(d => d.User)
					.WithMany(p => p.AspNetUserClaims)
					.HasForeignKey(d => d.UserId);
			});

			modelBuilder.Entity<AspNetUserLogins>(entity =>
			{
				entity.HasKey(e => new {e.LoginProvider, e.ProviderKey});

				entity.HasIndex(e => e.UserId);

				entity.Property(e => e.LoginProvider).HasMaxLength(128);

				entity.Property(e => e.ProviderKey).HasMaxLength(128);

				entity.Property(e => e.UserId).IsRequired();

				entity.HasOne(d => d.User)
					.WithMany(p => p.AspNetUserLogins)
					.HasForeignKey(d => d.UserId);
			});

			modelBuilder.Entity<AspNetUserRoles>(entity =>
			{
				entity.HasKey(e => new {e.UserId, e.RoleId});

				entity.HasIndex(e => e.RoleId);

				entity.HasOne(d => d.Role)
					.WithMany(p => p.AspNetUserRoles)
					.HasForeignKey(d => d.RoleId);

				entity.HasOne(d => d.User)
					.WithMany(p => p.AspNetUserRoles)
					.HasForeignKey(d => d.UserId);
			});

			modelBuilder.Entity<AspNetUserTokens>(entity =>
			{
				entity.HasKey(e => new {e.UserId, e.LoginProvider, e.Name});

				entity.Property(e => e.LoginProvider).HasMaxLength(128);

				entity.Property(e => e.Name).HasMaxLength(128);

				entity.HasOne(d => d.User)
					.WithMany(p => p.AspNetUserTokens)
					.HasForeignKey(d => d.UserId);
			});

			modelBuilder.Entity<AspNetUsers>(entity =>
			{
				entity.HasIndex(e => e.NormalizedEmail)
					.HasName("EmailIndex");

				entity.HasIndex(e => e.NormalizedUserName)
					.HasName("UserNameIndex")
					.IsUnique()
					.HasFilter("([NormalizedUserName] IS NOT NULL)");

				entity.Property(e => e.Email).HasMaxLength(256);

				entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

				entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

				entity.Property(e => e.UserName).HasMaxLength(256);
			});

			modelBuilder.Entity<Topics>(entity =>
			{
				entity.Property(e => e.CreationDate).HasColumnType("datetime");

				entity.Property(e => e.Creator)
					.IsRequired()
					.HasMaxLength(450);

				entity.Property(e => e.Description)
					.IsRequired()
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Title)
					.IsRequired()
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.HasOne(d => d.CreatorNavigation)
					.WithMany(p => p.Topics)
					.HasForeignKey(d => d.Creator)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Topics_AspNetUsers");
			});

			OnModelCreatingPartial(modelBuilder);
		}

		#endregion

		#region Private Methods

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

		#endregion
	}
}