using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasData
            (
                new Author
                {
                    AuthorID = 1,
                    Name = "Стивен Кинг"
                },
                new Author
                {
                    AuthorID = 2,
                    Name = "Рэй Брэдбери"
                },
                new Author
                {
                    AuthorID = 3,
                    Name = "Михаил Шолохов"
                }
            );
        }
    }
}
