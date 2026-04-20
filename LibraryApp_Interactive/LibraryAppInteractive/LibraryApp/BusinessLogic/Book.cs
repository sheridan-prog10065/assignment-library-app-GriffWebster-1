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

    //Check if a book has at least one available asset
    public bool CheckAvailablity()
    {
        foreach (LibraryAsset asset in _libAssetList)
        {
            if (asset.IsAvailable)
            {
                return true;
            }
        }
        return false;
    }

    //find the first available asset for the book
    public LibraryAsset FindNextAvailableAsset()
    {
        foreach (LibraryAsset asset in _libAssetList)
        {
            if (asset.IsAvailable)
            {
                return asset;
            }
        }

        return null;
    }

    //sets up a virtual method so paperbook and digital can use that if there is an available asset it sets its type as loaned.
    public virtual LibraryAsset BorrowBook()
    {
        LibraryAsset availableAsset = FindNextAvailableAsset();

        if (availableAsset == null)
        {
            return null;
        }

        availableAsset.Status = AssetStatus.Loaned;
        return availableAsset;
    }

    /// <summary>
    /// Reserves the next available asset for this book.
    /// </summary>
    /// <returns>The reserved asset, or null if no asset is available.</returns>
    public LibraryAsset ReserveBook()
    {
        LibraryAsset availableAsset = FindNextAvailableAsset();

        if (availableAsset == null)
        {
            return null;
        }

        availableAsset.Status = AssetStatus.Reserved;
        return availableAsset;
    }

    /// <summary>
    /// Finds an asset by its library ID.
    /// </summary>
    /// <param name="libID">The asset ID to search for.</param>
    /// <returns>The matching asset, or null if not found.</returns>
    public LibraryAsset FindAssetByID(int libID)
    {
        foreach (LibraryAsset asset in _libAssetList)
        {
            if (asset.LibID == libID)
            {
                return asset;
            }
        }

        return null;
    }

    /// <summary>
    /// Returns a borrowed asset.
    /// The base version removes the loan and sets the asset back to available.
    /// It returns a tuple with late information and fine.
    /// Derived classes override this to apply specific fine rules.
    public virtual (TimeSpan, int, decimal) ReturnBook(int libID)
    {
        LibraryAsset asset = FindAssetByID(libID);

        // If the asset doesn't exist or it was never loaned,
        // no return can happen.
        if (asset == null || asset.LoanPeriod == null)
        {
            return (TimeSpan.Zero, 0, 0m);
        }

        LoanPeriod completedLoan = asset.LoanPeriod.Value;
        TimeSpan latePeriod = completedLoan.LatePeriod;

        int lateDays = 0;

        // If overdue, round up to whole late days.
        if (latePeriod.TotalDays > 0)
        {
            lateDays = (int)Math.Ceiling(latePeriod.TotalDays);
        }

        asset.Status = AssetStatus.Available;
        asset.LoanPeriod = null;

        return (latePeriod, lateDays, 0m);
    }

    //public LibraryAsset FindAssetByID()
}
