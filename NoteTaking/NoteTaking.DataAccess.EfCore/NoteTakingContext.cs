using Microsoft.EntityFrameworkCore;
using NoteTaking.DataAccess.EfCore.Models;

namespace NoteTaking.DataAccess.EfCore
{
	public class NoteTakingContext : DbContext
	{
		private const int NAME_MAX_LENGTH = 50;

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
			optionsBuilder.UseNpgsql(@"User ID=notetaking;Password=Abcd123;Host=localhost;Port=5432;Database=NoteTaking;Pooling=true;");
			base.OnConfiguring(optionsBuilder);
		}

		private static void SetupUserDao(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<UserDao>()
				.Property(u => u.FirstName)
				.IsRequired()
				.HasMaxLength(NAME_MAX_LENGTH);

			modelBuilder.Entity<UserDao>()
				.Property(u => u.Lastname)
				.IsRequired()
				.HasMaxLength(NAME_MAX_LENGTH);

			modelBuilder.Entity<UserDao>()
				.Property(u => u.ConcurrencyToken)
				.ValueGeneratedOnAddOrUpdate()
				.IsConcurrencyToken();
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