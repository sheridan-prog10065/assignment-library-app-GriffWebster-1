using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAppInteractive.BusinessLogic;

public class DigitalBook : Book
{
    public DigitalBook(string bookName, string bookISBN, string[] authors) : base(bookName, bookISBN, authors)
    {
    }
}
