using Entities.Models;
using System.Collections.Generic;

namespace Catalog
{
    public interface IBookRepository
    {
        Book GetBookID(int id);
        void CreateBook(Book book);
        void DeleteBook(Book book);
        void Save();
    }
}
