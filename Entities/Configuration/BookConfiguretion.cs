using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Entities.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData
            (
                new Book
                {
                    BookID = 1,
                    Name = "Кладбище домашних животных.",
                    Year = 1983
                },
                new Book
                {
                    BookID = 2,
                    Name = "Вино из одуванчиков.",
                    Year = 1957
                },
                new Book
                {
                    BookID = 3,
                    Name = "Смерть - дело одинокое.",
                    Year = 1985
                },
                new Book
                {
                    BookID = 4,
                    Name = "Летать или бояться.",
                    Year = 2018
                }
            );
        }
    }
}
