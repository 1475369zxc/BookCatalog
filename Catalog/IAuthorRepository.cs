using Entities.Models;
using Entities.ViewModels;
using System.Collections.Generic;

namespace Catalog
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAuthors();
        Author GetAuthorID(int id);
        void CreateAuthor(Author author);
        void DeleteAuthor(Author author);
        void Save();
    }
}
