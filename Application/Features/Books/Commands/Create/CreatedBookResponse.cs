using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.Commands.Create;

public class CreatedBookResponse
{
    public Guid Id { get; set; }
    public string BookName { get; set; }
    public string BookAuthor { get; set; }
    public DateTime PublishDate { get; set; }
    public string BookImage { get; set; }
    public string BookTitle { get; set; }
    public string BookDescription { get; set; }
    public string PublishHouse { get; set; }

    public DateTime CreatedDate { get; set; }
    public int BookStatus { get; set; } 
}
