using Microsoft.EntityFrameworkCore;
using NoteTaking.DataAccess.EfCore.Models;

namespace NoteTaking.DataAccess.EfCore
{
	public class NoteTakingContext : DbContext
	{
		private const int NAME_MAX_LENGTH = 50;
		private const int USER_NAME_MAX_LENGTH = 20;

		public DbSet<UserDao> Users { get; set; }

		public DbSet<NoteDao> Notes { get; set; }

		/// <inheritdoc />
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			SetupUserDao(modelBuilder);
			SetupNoteDao(modelBuilder);
		}

		/// <inheritdoc />
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			// TODO: add to config.
			optionsBuilder.UseNpgsql(@"User ID=notetaking;Password=Abcd123;Host=localhost;Port=5432;Database=NoteTaking;Pooling=true;");
			base.OnConfiguring(optionsBuilder);
		}

		private static void SetupUserDao(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<UserDao>()
				.HasIndex(s => s.UserName)
				.IsUnique();

			modelBuilder.Entity<UserDao>()
				.Property(u => u.UserName)
				.IsRequired()
				.HasMaxLength(USER_NAME_MAX_LENGTH);

			modelBuilder.Entity<UserDao>()
				.Property(u => u.FirstName)
				.IsRequired()
				.HasMaxLength(NAME_MAX_LENGTH);

			modelBuilder.Entity<UserDao>()
				.Property(u => u.Lastname)
				.IsRequired()
				.HasMaxLength(NAME_MAX_LENGTH);
		}

		private static void SetupNoteDao(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<NoteDao>()
				.Property(n => n.Text)
				.IsRequired();

			modelBuilder.Entity<NoteDao>()
				.Property(u => u.ConcurrencyToken)
				.ValueGeneratedOnAddOrUpdate()
				.IsConcurrencyToken();
		}
	}
}