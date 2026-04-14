using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAppInteractive.BusinessLogic;

public class LibraryAsset
{
    private Book _book;
    private int _libID;
    private AssetStatus _status;
    private LoanPeriod? _loanPeriod;

    public int LibID
    {
        get { return _libID; }
        set { _libID = value; }
    }

    public AssetStatus Status
    {
        get { return _status; }
        set { _status = value; }
    }

    public LoanPeriod? LoanPeriod
    {
        get { return _loanPeriod; }
    }

    public bool IsAvailable
    {
        get { return _status == AssetStatus.Available; }
    }

    public LibraryAsset(Book book, int libID)
    {
        _book = book;
        _libID = libID;
        _status = AssetStatus.Available;
        _loanPeriod = null;
    }


}
