using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations;


public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.BookName).HasColumnName("BookName").IsRequired();

        builder.Property(b => b.BookAuthor).HasColumnName("BookAuthor");
        builder.Property(b => b.PublishDate).HasColumnName("PublishDate");
        builder.Property(b => b.BookImage).HasColumnName("BookImage");
        builder.Property(b => b.BookTitle).HasColumnName("BookTitle");
        builder.Property(b => b.BookDescription).HasColumnName("BookDescription");
        builder.Property(b => b.PublishHouse).HasColumnName("PublishHouse");

        builder.Property(b => b.BookBarrowNameSurname).HasColumnName("BookBarrowNameSurname");
        builder.Property(b => b.BookReturnDate).HasColumnName("BookReturnDate");
        builder.Property(b => b.BookLendDate).HasColumnName("BookLendDate");
        builder.Property(b => b.BookStatus).HasColumnName("BookStatus");
      



        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b => b.BookName, name: "UK_Books_Name").IsUnique();



        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}