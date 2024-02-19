using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Book:Entity<Guid>
{
    public string BookName { get; set; }
    public string BookAuthor { get; set; }   
    public DateTime? PublishDate { get; set; }
    public string? BookImage { get; set; }
    public string? BookTitle { get; set; }
    public string? BookDescription { get; set; }
    public string? PublishHouse { get; set; }

    public string? BookBarrowNameSurname { get; set; }
    public DateTime? BookReturnDate { get; set; }
    public DateTime? BookLendDate { get; set; }
    public int BookStatus { get; set; }
    public Book()
    {
        
    }
    public Book(string _bookName,string _bookAuthor,DateTime _publishDate,string _bookImage,string _bookTitle,string _bookDescription,string _publishHouse,
      string _bookBarrowNameSurname,DateTime _bookReturnDate ,DateTime _bookLendDate,int _bookStatus)
    {
        BookName= _bookName;
        BookAuthor= _bookAuthor;
        PublishDate= _publishDate;
        BookImage= _bookImage;
        BookTitle= _bookTitle;
        BookDescription= _bookDescription;
        PublishHouse= _publishHouse;
        BookBarrowNameSurname = _bookBarrowNameSurname;
        BookReturnDate= _bookReturnDate;
         BookLendDate= _bookLendDate;
        BookStatus = _bookStatus;
   
            

    }
}
