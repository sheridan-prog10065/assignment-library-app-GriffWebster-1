using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAppInteractive.BusinessLogic;

public class PaperBook : Book
{
    public PaperBook(string bookName, string bookISBN, string[] authors) : base(bookName, bookISBN, authors)
    {
    }


}
