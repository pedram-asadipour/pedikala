using CommentManagement.Domain.ArticleCommentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommentManagement.Infrastructure.EFCore.Mapping
{
    public class ArticleCommentMapping : IEntityTypeConfiguration<ArticleComment>
    {
        public void Configure(EntityTypeBuilder<ArticleComment> builder)
        {
            builder.ToTable("ArticleComments");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.Message)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(x => x.WebSite)
                .HasMaxLength(500);

            // builder.HasOne(x => x.Parent)
            //     .WithMany(x => x.Children)
            //     .HasForeignKey(x => x.ParentId);
        }
    }
}