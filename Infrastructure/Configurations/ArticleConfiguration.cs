using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal sealed class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
	public void Configure(EntityTypeBuilder<Article> builder)
	{
		builder.ToTable(nameof(Article));

		builder.HasKey(x => x.Id);

		builder.Property(x => x.Title).IsRequired();

		builder.HasOne(x => x.Author).WithMany();

		builder.HasOne(x => x.Category).WithMany();
	}
}
