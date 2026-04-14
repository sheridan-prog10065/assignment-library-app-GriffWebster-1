using System;
using System.Collections.Generic;
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

    public Library()
    {
        _bookList = new List<Book>();
        _libIDGenoratorSeed = DEFAULT_LIBID_START;
        CreateDefaultBooks();

    }

    public List<Book> Books 
    { 
        get { return _bookList; } 
    }

    private void CreateDefaultBooks()
    {
        if (_bookList.Count > 0)
        {
            return;
        }

        RegisterBook("Harry Potter", "9375628463184", new string[] { "J.K. Rowling" }, BookType.Paper, 5);

        RegisterBook("Dune", "9373640129403", new string[] { "Frank Herbert" }, BookType.Digital, 5);

        RegisterBook("The Quran", "9286005439111", new string[] { "n/a" }, BookType.Paper, 5);
    }

    private int DetermineLibID()
    {

    }

    public Book RegisterBook(string bookName, string bookISBN, string[] authors, BookType bookType, int nCopies)
    {

    }

    public Book FindBookByName(string bookName)
    {

    }

    public Book FindBookByISBN(string bookISBN)
    {

    }
}
