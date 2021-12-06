using Catalog;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly RepositoryContext repository;
        public BookRepository(RepositoryContext _repository)
        {
            repository = _repository;
        }

        public void CreateBook(Book book) => repository.Set<Book>().Add(book);

        public Book GetBookID(int id)
        {
            repository.Books.Include(b => b.Authors).ToList().First(b => b.BookID == id);
            return repository.Set<Book>().Where(b => b.BookID.Equals(id)).
                SingleOrDefault();
        }

        public void Save() => repository.SaveChanges();
        public void DeleteBook(Book book) => repository.Remove(book);
    }
}
