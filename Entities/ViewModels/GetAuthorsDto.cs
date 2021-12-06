using System.ComponentModel.DataAnnotations;

namespace Entities.ViewModels
{
    public class GetAuthorsDto
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }
    }
}
