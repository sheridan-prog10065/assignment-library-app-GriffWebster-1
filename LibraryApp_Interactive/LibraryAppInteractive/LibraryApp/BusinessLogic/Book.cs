using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAppInteractive.BusinessLogic;

public class Book
{
    private string _bookName;
    private string _bookISBN;
    private List<string> _bookAuthorList;
    private List<LibraryAsset> _libAssetList;

    public string Name
    {
        get { return _bookName; }
        set { _bookName = value; }
    }

    public string ISBN
    {
        get { return _bookISBN; }
        set { _bookISBN = value; }
    }

    public List<string> Authors
    {
        get { return _bookAuthorList;  }
    }

    public IEnumerable<LibraryAsset> Assets
    {
        get { return _libAssetList; }

    }

    public Book(string bookName, string bookISBN, string[] authors)
    {
        _bookName = bookName;
        _bookISBN = bookISBN;
        _bookAuthorList = new List<string>(authors);
        _libAssetList = new List<LibraryAsset>();
    }

    public void AddAsset(LibraryAsset asset)
    {
        _libAssetList.Add(asset);
    }

    public override string ToString()
    {
        string authorText = string.Join(", ", _bookAuthorList);
        return $"{_bookName} ISBN: {_bookISBN} by {authorText}";
    }
}
