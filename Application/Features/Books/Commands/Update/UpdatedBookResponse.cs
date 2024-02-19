using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.Commands.Update;

public class UpdatedBookResponse
{
    public Guid Id { get; set; }
    public string BookBarrowNameSurname { get; set; }
    public DateTime BookReturnDate { get; set; }
    public DateTime BookLendDate { get; set; }
    public int BookStatus { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
