using Catalog;
using Entities;
using Entities.Models;
using Entities.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly RepositoryContext repository;
        public AuthorRepository(RepositoryContext _repository)
        {
            repository = _repository;
        }

        public IEnumerable<Author> GetAuthors() => repository.Authors.ToList();

        public Author GetAuthorID(int id)
        {
            repository.Authors.Include(b => b.Books).ToList().First(b => b.AuthorID == id);
            return repository.Set<Author>().Where(a => a.AuthorID.Equals(id)).SingleOrDefault();
        }

        public void CreateAuthor(Author author) => repository.Set<Author>().Add(author);
        public void Save() => repository.SaveChanges();

        public void DeleteAuthor(Author author) => repository.Remove(author);
    }
}
