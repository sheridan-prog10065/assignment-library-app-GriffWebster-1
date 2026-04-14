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
