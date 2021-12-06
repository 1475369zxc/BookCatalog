using System.Collections.Generic;

namespace Entities.ViewModels
{
    public class GetBookDto
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public List<GetAuthorsDto> Authors { get; set; }
    }
}
