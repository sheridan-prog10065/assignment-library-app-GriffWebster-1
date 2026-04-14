using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAppInteractive.BusinessLogic;

public struct LoanPeriod
{
    private DateTime _borrowedOn;
    private DateTime _returnedOn;
    private DateTime _dueDate;

    public LoanPeriod(DateTime borrowedOn, DateTime returnedOn) 
    { 
        _borrowedOn = borrowedOn;
        _returnedOn = returnedOn;
    }

    public DateTime BorrowedOn
    {
        get { return _borrowedOn; }
    }

    public DateTime ReturnedOn
    {
        get { return _returnedOn; }
    }

    public DateTime DueDate
    {
        get { return _dueDate; }
    }

    public TimeSpan LoanDuration
    {
        get { return _dueDate - _borrowedOn; }
    }

    public TimeSpan LatePeriod
    {
        get { return _returnedOn - _dueDate; }
    }


}
