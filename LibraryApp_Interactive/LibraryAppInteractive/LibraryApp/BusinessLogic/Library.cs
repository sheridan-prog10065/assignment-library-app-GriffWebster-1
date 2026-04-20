using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LibraryAppInteractive.BusinessLogic;

public class Library
{
    //Type of book
    public enum BookType
    {
        Paper = 1,
        Digital,
        Audio
    }

    private List<Book> _bookList;
    private int _libIDGenoratorSeed;
    private const int DEFAULT_LIBID_START = 100;

    public List<Book> Books
    {
        get { return _bookList; }
    }

    public Library()
    {
        _bookList = new List<Book>();
        _libIDGenoratorSeed = DEFAULT_LIBID_START;
        CreateDefaultBooks();

    }

    /*
    private int DetermineLibID()
    {

    }
    */

private void CreateDefaultBooks()
{

    RegisterBook("Harry Potter", "9375628463184", new string[] { "J.K. Rowling" }, BookType.Paper, 5);

    RegisterBook("Dune", "9373640129403", new string[] { "Frank Herbert" }, BookType.Digital, 5);

    RegisterBook("The Quran", "9286005439111", new string[] { "n/a" }, BookType.Paper, 5);
}



   
    

    public Book RegisterBook(string bookName, string bookISBN, string[] authors, BookType bookType, int nCopies)
    {
        List<string> authorList = new List<string>(authors);
        Book newBook;

        if (bookType == BookType.Paper)
        {
            newBook = new PaperBook(bookName, bookISBN, authors);
        }
        else //(bookType == BookType.Digital)
        {
            newBook = new DigitalBook(bookName, bookISBN, authors);
        }
        /*
        else
        {
            throw new Exeption();
        }
        */

        _bookList.Add(newBook);

        return newBook;

    }

    //Got ai help with the finding functionality
public Book FindBookByName(string bookName)
{
        foreach (Book book in _bookList)
        {
            if (book.Name.ToLower() == bookName.ToLower())
            { 
                return book;
            }
        }

        return null;

}

public Book FindBookByISBN(string bookISBN)
{
        foreach (Book book in _bookList)
        {
            if (book.ISBN == bookISBN)
            {
                return book;
            }
        }

        return null;

}
*/


}
